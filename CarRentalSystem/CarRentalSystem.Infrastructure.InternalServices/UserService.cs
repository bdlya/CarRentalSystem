using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Interfaces;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Infrastructure.Data.Policies;
using CarRentalSystem.Infrastructure.ExceptionHandling.Exceptions;
using CarRentalSystem.Services.InternalInterfaces;

namespace CarRentalSystem.Infrastructure.InternalServices
{
    public class UserService: IUserService
    {
        private readonly IRentalRepository<User> _users;
        private readonly IMapper _mapper;
        private readonly ITokenCreatorService _tokenCreator;

        public UserService(IRentalRepository<User> users, IMapper mapper, ITokenCreatorService tokenCreator)
        {
            _users = users;
            _mapper = mapper;
            _tokenCreator = tokenCreator;
        }

        public async Task<UserModel> AuthenticateAsync(string login, string password)
        {
            UserModel user = _mapper.Map<UserModel>(await _users.IncludeAsync(token => token.RefreshToken)
                .ContinueWith(users => users.Result
                    .FirstOrDefault(u => u.Login == login)));

            if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                throw new UnauthorizedAccessException();
            }

            user = await _tokenCreator.CreateTokensForUserAsync(user);

            await _users.UpdateAsync(_mapper.Map<User>(user));

            return _mapper.Map<UserModel>(user);
        }

        public async Task RegisterUserAsync(UserModel model, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            model.Role = Policy.Customer;
            model.PasswordHash = passwordHash;
            model.PasswordSalt = passwordSalt;

            await _users.CreateAsync(_mapper.Map<User>(model));
        }

        public async Task RemoveTokenAsync(UserModel model)
        {
            UserModel user = _mapper.Map<UserModel>(await _users.GetAsync()
                .ContinueWith(users => users.Result
                    .FirstOrDefault(u => u.Login == model.Login)));
            user.Token = null;

            await _users.UpdateAsync(_mapper.Map<User>(user));
        }

        public async Task<RefreshTokenModel> RefreshTokenAsync(string refreshToken)
        {
            UserModel user = _mapper.Map<UserModel>(await _users.IncludeAsync(u => u.RefreshToken)
                .ContinueWith(users => users.Result
                    .SingleOrDefault(u => u.RefreshToken.Token == refreshToken)));
            
            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            RefreshTokenModel currentRefreshToken = user.RefreshToken;

            if (!currentRefreshToken.IsActive)
            {
                throw new UnauthorizedAccessException();
            }

            user = await _tokenCreator.CreateTokensForUserAsync(user);

            await _users.UpdateAsync(_mapper.Map<User>(user));

            return user.RefreshToken;
        }

        public async Task AddOrderAsync(int id, OrderModel order)
        {
            UserModel user = _mapper.Map<UserModel>(await _users.FindByIdAsync(id));

            if (user == null)
            {
                throw new EntityNotFoundException(nameof(User));
            }

            user.Orders.Add(order);

            await _users.UpdateAsync(_mapper.Map<User>(user));
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using var hmac = new HMACSHA512(storedSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return !computedHash.Where((t, i) => t != storedHash[i]).Any();
        }
    }
}