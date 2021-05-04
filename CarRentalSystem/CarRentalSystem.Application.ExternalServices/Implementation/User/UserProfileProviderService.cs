using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.ExternalServices.Interfaces.User;
using CarRentalSystem.Application.InternalServices.Interfaces.Main;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.ExternalServices.Implementation.User
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