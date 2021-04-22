using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.Data.Models;

namespace CarRentalSystem.Services.InternalInterfaces
{
    public interface IUserService
    {
        Task<UserModel> Authenticate(string login, string password);
        Task RegisterUser(UserModel model, string password);
        Task RemoveToken(UserModel model);
        Task<RefreshTokenModel> RefreshToken(string refreshToken);
    }
}