using CarRentalSystem.Infrastructure.Data.Models;

namespace CarRentalSystem.Services.InternalInterfaces
{
    public interface IUserService
    {
        UserModel Authenticate(string login, string password);
        void RegisterUser(UserModel model);
        void RemoveToken(UserModel model);
    }
}