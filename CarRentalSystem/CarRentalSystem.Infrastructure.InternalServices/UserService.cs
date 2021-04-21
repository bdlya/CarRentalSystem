using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Entities.Helpers;
using CarRentalSystem.Domain.Interfaces;
using CarRentalSystem.Infrastructure.Data.Models;
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
            User user = await Task.Run(() => user = _users.Get().FirstOrDefault(u => u.Login == login));

            if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                throw new UnauthorizedAccessException();
            }

            user = _tokenCreator.CreateTokenForUser(user);
            await Task.Run(() =>_users.Update(user));

            return _mapper.Map<UserModel>(user);
        }

        public async Task RegisterUser(UserModel model, string password)
        {
            User user = _mapper.Map<User>(model);
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.Role = Role.Customer;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await Task.Run(() =>_users.Create(user));
        }

        public async Task RemoveToken(UserModel model)
        {
            User user = await Task.Run(() => user = _users.Get().FirstOrDefault(u => u.Login == _mapper.Map<User>(model).Login)) ;
            user.Token = null;

            await Task.Run(() =>_users.Update(user));
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