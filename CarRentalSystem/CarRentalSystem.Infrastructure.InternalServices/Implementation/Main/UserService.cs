using AutoMapper;
using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.Data.Models.Support;
using CarRentalSystem.Application.InternalInterfaces.Main;
using CarRentalSystem.Application.InternalInterfaces.Support;
using CarRentalSystem.Domain.Entities.Main;
using CarRentalSystem.Domain.Interfaces.Repository;
using CarRentalSystem.Infrastructure.Data.Authorization;
using CarRentalSystem.Infrastructure.ExceptionHandling.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.InternalServices.Implementation.Main
{
    public class UserService: IUserService
    {
        private readonly ICarRentalSystemRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenCreatorService _tokenCreator;

        public UserService(ICarRentalSystemRepository<User> userRepository, IMapper mapper, ITokenCreatorService tokenCreator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenCreator = tokenCreator;
        }

        public async Task<UserModel> AuthenticateAsync(string login, string password)
        {
            var users = await _userRepository.GetAsQueryable();
            UserModel user = _mapper.Map<UserModel>(users
                .Include(u => u.RefreshToken)
                .FirstOrDefault(u => u.Login == login));
            
            if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                throw new UnauthorizedAccessException();
            }

            user = await _tokenCreator.CreateTokensForUserAsync(user);

            await _userRepository.UpdateAsync(_mapper.Map<User>(user));

            return _mapper.Map<UserModel>(user);
        }

        public async Task RegisterUserAsync(UserModel model, string password, string role)
        {
            var users = await _userRepository.GetAsQueryable();
            UserModel user = _mapper.Map<UserModel>(users.FirstOrDefault(u => u.Login == model.Login));

            if (user != null)
            {
                throw new LoginAlreadyExistsException(model.Login);
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            model.Role = role;
            model.PasswordHash = passwordHash;
            model.PasswordSalt = passwordSalt;

            await _userRepository.CreateAsync(_mapper.Map<User>(model));
        }

        public async Task RemoveTokenAsync(UserModel model)
        {
            var users = await _userRepository.GetAsQueryable();
            UserModel user = _mapper.Map<UserModel>(users.FirstOrDefault(u => u.Login == model.Login));

            user.Token = null;

            await _userRepository.UpdateAsync(_mapper.Map<User>(user));
        }

        public async Task<RefreshTokenModel> RefreshTokenAsync(string refreshToken)
        {
            var users = await _userRepository.GetAsQueryable();
            UserModel user = _mapper.Map<UserModel>(users
                .Include(u => u.RefreshToken)
                .FirstOrDefault(u => u.RefreshToken.Token == refreshToken));

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

            await _userRepository.UpdateAsync(_mapper.Map<User>(user));

            return user.RefreshToken;
        }

        public async Task AddOrderAsync(int id, OrderModel order)
        {
            var users = await _userRepository.GetAsQueryable();
            UserModel user = _mapper.Map<UserModel>(users
                .Include(u => u.Orders)
                .FirstOrDefault(u => u.Id == id));

            if (user == null)
            {
                throw new EntityNotFoundException(nameof(User));
            }

            user.Orders.Add(order);

            await _userRepository.UpdateAsync(_mapper.Map<User>(user));
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.RemoveAsync(await _userRepository.FindByIdAsync(id));
        }

        public async Task<IQueryable<UserModel>> GetAllAdminsAsync()
        {
            var users = await _userRepository.GetAsQueryable();

            return users
                .Where(user => user.Role == Policy.Administrator)
                .Select(user => _mapper.Map<UserModel>(user));
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