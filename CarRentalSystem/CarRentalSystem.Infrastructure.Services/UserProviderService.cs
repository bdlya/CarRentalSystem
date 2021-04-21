using System.Threading.Tasks;
using AutoMapper;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;
using CarRentalSystem.View.ViewModels;
using CarRentalSystem.View.ViewModels.Base;

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

        public async Task<UserViewModel> Authenticate(AuthenticationViewModel model)
        {
            UserModel userModel = await _userService.Authenticate(model.Login, model.Password);
            return _mapper.Map<UserViewModel>(userModel);
        }

        public async Task RegisterUser(RegistrationViewModel model)
        {
            UserModel userModel = _mapper.Map<UserModel>(model);
            await _userService.RegisterUser(userModel, model.Password);
        }

        public async Task RemoveToken(UserViewModel viewModel)
        {
            await _userService.RemoveToken(_mapper.Map<UserModel>(viewModel));
        }
    }
}