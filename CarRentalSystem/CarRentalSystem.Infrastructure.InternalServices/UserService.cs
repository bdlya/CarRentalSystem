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

        public async Task<UserModel> Authenticate(string login, string password)
        {
            User user = await _users.Include(token => token.RefreshToken)
                .ContinueWith(users => users.Result
                    .FirstOrDefault(u => u.Login == login));

            if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                throw new UnauthorizedAccessException();
            }

            user = await _tokenCreator.CreateTokensForUser(user);

            await _users.Update(user);

            return _mapper.Map<UserModel>(user);
        }

        public async Task RegisterUser(UserModel model, string password)
        {
            User user = _mapper.Map<User>(model);
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.Role = Policy.Customer;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _users.Create(user);
        }

        public async Task RemoveToken(UserModel model)
        {
            User user = await _users.Get()
                .ContinueWith(users => users.Result
                    .FirstOrDefault(u => u.Login == _mapper.Map<User>(model).Login));
            user.Token = null;

            await _users.Update(user);
        }

        public async Task<RefreshTokenModel> RefreshToken(string refreshToken)
        {
            User user = await _users.Include(u => u.RefreshToken)
                .ContinueWith(users => users.Result
                    .SingleOrDefault(u => u.RefreshToken.Token == refreshToken));
            
            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            RefreshToken currentRefreshToken = user.RefreshToken;

            if (!currentRefreshToken.IsActive)
            {
                throw new UnauthorizedAccessException();
            }

            user = await _tokenCreator.CreateTokensForUser(user);

            await _users.Update(user);

            return _mapper.Map<RefreshTokenModel>(user.RefreshToken);
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