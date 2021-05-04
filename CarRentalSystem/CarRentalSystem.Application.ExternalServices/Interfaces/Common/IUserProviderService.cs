using System.Threading.Tasks;
using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.Data.Models.Support;

namespace CarRentalSystem.Application.ExternalServices.Interfaces.Common
{
    public interface IUserProviderService
    {
        Task<UserModel> AuthenticateAsync(AuthenticationModel model);
        Task RegisterUserAsync(RegistrationModel model);
        Task RemoveTokenAsync(UserModel viewModel);
        Task<RefreshTokenModel> RefreshTokenAsync(string refreshToken);
    }
}