using AutoMapper;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Infrastructure.Data.Models.Base;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;
using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.Data.Policies;

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

        public async Task<UserModel> AuthenticateAsync(AuthenticationModel model)
        {
            return await _userService.AuthenticateAsync(model.Login, model.Password);
        }

        public async Task RegisterUserAsync(RegistrationModel model)
        {
            UserModel userModel = _mapper.Map<UserModel>(model);
            await _userService.RegisterUserAsync(userModel, model.Password, Policy.Customer);
        }

        public async Task RemoveTokenAsync(UserModel viewModel)
        {
            await _userService.RemoveTokenAsync(viewModel);
        }

        public async Task<RefreshTokenModel> RefreshTokenAsync(string refreshToken)
        {
            return await _userService.RefreshTokenAsync(refreshToken);
        }
    }
}