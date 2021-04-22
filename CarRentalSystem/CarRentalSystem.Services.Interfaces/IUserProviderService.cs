using System.Threading.Tasks;
using CarRentalSystem.View.ViewModels;
using CarRentalSystem.View.ViewModels.Base;

namespace CarRentalSystem.Services.Interfaces
{
    public interface IUserProviderService
    {
        Task<UserViewModel> Authenticate(AuthenticationViewModel model);
        Task RegisterUser(RegistrationViewModel model);
        Task RemoveToken(UserViewModel viewModel);
        Task<RefreshTokenViewModel> RefreshToken(string refreshToken);
    }
}