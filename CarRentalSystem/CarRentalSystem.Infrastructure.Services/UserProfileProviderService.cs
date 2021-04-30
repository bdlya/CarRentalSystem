using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;

namespace CarRentalSystem.Infrastructure.Services
{
    public class UserProfileProviderService: IUserProfileProviderService
    {
        private readonly IOrderService _orderService;

        public UserProfileProviderService(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task CancelOrderAsync(int orderId)
        {
            await _orderService.CancelOrderAsync(orderId);
        }

        public async Task<OrderModel> GetOrderAsync(int orderId)
        {
            return await _orderService.GetOrderAsync(orderId);
        }
    }
}