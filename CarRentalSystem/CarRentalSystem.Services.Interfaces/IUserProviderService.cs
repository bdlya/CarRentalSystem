using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Infrastructure.Data.Models.Base;
using System.Threading.Tasks;

namespace CarRentalSystem.Services.Interfaces
{
    public interface IUserProviderService
    {
        Task<UserModel> AuthenticateAsync(AuthenticationModel model);
        Task RegisterUserAsync(RegistrationModel model);
        Task RemoveTokenAsync(UserModel viewModel);
        Task<RefreshTokenModel> RefreshTokenAsync(string refreshToken);
    }
}