using System.Linq;
using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.Data.Models;

namespace CarRentalSystem.Services.InternalInterfaces
{
    public interface IUserService
    {
        Task<UserModel> AuthenticateAsync(string login, string password);
        Task RegisterUserAsync(UserModel model, string password, string role);
        Task RemoveTokenAsync(UserModel model);
        Task<RefreshTokenModel> RefreshTokenAsync(string refreshToken);
        Task AddOrderAsync(int id, OrderModel order);
        Task DeleteUserAsync(int id);
        Task<IQueryable<UserModel>> GetAllAdminsAsync();
    }
}