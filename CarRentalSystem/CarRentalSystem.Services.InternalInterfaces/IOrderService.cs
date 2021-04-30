using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.Data.Models;

namespace CarRentalSystem.Services.InternalInterfaces
{
    public interface IOrderService
    {
        Task<OrderModel> CreateOrderAsync(int userId, int carId);
        Task ChooseDatesAsync(int orderId, BookingDatesModel bookingDates);
        Task AddAdditionalServicesAsync(int orderId, List<OrderAdditionalServiceModel> orderAdditionalServices);
        Task<OrderModel> GetOrderAsync(int orderId);
        Task<IQueryable<OrderModel>> GetUserOrdersAsync(int userId);
        Task<bool> CheckOrderActivityAsync(OrderModel order);
    }
}