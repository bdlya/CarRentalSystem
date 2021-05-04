using System.Threading.Tasks;
using CarRentalSystem.Application.Data.Models.Main;

namespace CarRentalSystem.Application.ExternalInterfaces.User
{
    public interface IUserProfileProviderService
    {
        Task CancelOrderAsync(int orderId);
        Task<OrderModel> GetOrderAsync(int orderId);
    }
}