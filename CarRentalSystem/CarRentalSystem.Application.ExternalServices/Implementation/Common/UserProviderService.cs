using AutoMapper;
using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.Data.Models.Support;
using CarRentalSystem.Application.ExternalServices.Interfaces.Common;
using CarRentalSystem.Application.InternalServices.Interfaces.Main;
using CarRentalSystem.Infrastructure.Data.Authorization;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.ExternalServices.Implementation.Common
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