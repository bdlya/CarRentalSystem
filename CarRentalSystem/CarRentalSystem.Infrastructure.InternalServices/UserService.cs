using System.Linq;
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

        public UserModel Authenticate(string login, string password)
        {
            User user = _users.Get().FirstOrDefault(u => u.Login == login && u.Password == password);

            if (user == null)
            {
                return null;
            }

            user = _tokenCreator.CreateTokenFor(user);
            _users.Update(user);

            return _mapper.Map<UserModel>(user);
        }

        public void RegisterUser(UserModel model)
        {
            User user = _mapper.Map<User>(model);
            user.Role = Role.Customer;

            _users.Create(user);
        }

        public void RemoveToken(UserModel model)
        {
            User user = _users.Get().FirstOrDefault(u => u.Login == _mapper.Map<User>(model).Login );
            user.Token = null;

            _users.Update(user);
        }
    }
}