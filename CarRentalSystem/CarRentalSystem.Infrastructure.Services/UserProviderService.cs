using System.Threading.Tasks;
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

        public async Task<UserViewModel> Authenticate(AuthenticationViewModel model)
        {
            UserModel userModel = await Task.Run(() =>_userService.Authenticate(model.Login, model.Password));
            return _mapper.Map<UserViewModel>(userModel);
        }

        public async Task RegisterUser(UserViewModel model)
        {
            await Task.Run(() => _userService.RegisterUser(_mapper.Map<UserModel>(model)));
        }

        public async Task RemoveToken(UserViewModel viewModel)
        {
            await Task.Run(() => _userService.RemoveToken(_mapper.Map<UserModel>(viewModel)));
        }
    }
}