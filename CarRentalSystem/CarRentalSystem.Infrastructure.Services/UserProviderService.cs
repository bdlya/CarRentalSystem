using System.Data;
using AutoMapper;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;
using CarRentalSystem.View.ViewModels;

namespace CarRentalSystem.Infrastructure.Services
{
    public class UserProviderService: IUserProviderService
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserProviderService(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public UserViewModel Authenticate(AuthenticationViewModel model)
        {
            UserModel userModel = _userService.Authenticate(model.Login, model.Password);

            if (userModel == null)
            {
                return null;
            }

            return  _mapper.Map<UserViewModel>(userModel);
        }
    }
}