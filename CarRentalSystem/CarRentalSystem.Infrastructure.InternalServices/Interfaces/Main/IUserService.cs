using System.Linq;
using System.Threading.Tasks;
using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.Data.Models.Support;

namespace CarRentalSystem.Application.InternalServices.Interfaces.Main
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