using System.Threading.Tasks;
using CarRentalSystem.View.ViewModels;

namespace CarRentalSystem.Services.Interfaces
{
    public interface IUserProviderService
    {
        Task<UserViewModel> Authenticate(AuthenticationViewModel model);
        Task RegisterUser(UserViewModel model);
        Task RemoveToken(UserViewModel viewModel);
    }
}