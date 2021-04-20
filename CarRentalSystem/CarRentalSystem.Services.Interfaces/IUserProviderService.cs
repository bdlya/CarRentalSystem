using CarRentalSystem.View.ViewModels;

namespace CarRentalSystem.Services.Interfaces
{
    public interface IUserProviderService
    {
        UserViewModel Authenticate(AuthenticationViewModel model);
        void RegisterUser(UserViewModel model);
    }
}