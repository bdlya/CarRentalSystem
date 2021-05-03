using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.Data.Models;

namespace CarRentalSystem.Services.Interfaces
{
    public interface IUserProfileProviderService
    {
        Task CancelOrderAsync(int orderId);
        Task<OrderModel> GetOrderAsync(int orderId);
    }
}