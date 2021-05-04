using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.Data.Models.Support;

namespace CarRentalSystem.Application.InternalServices.Interfaces.Main
{
    public interface IOrderService
    {
        Task<OrderModel> CreateOrderAsync(int userId, int carId);

        Task ChooseDatesAsync(int orderId, BookingDatesModel bookingDates);

        Task AddAdditionalServicesAsync(int orderId, List<OrderAdditionalWorkModel> orderAdditionalServices);

        Task<OrderModel> GetOrderAsync(int orderId);

        Task<IQueryable<OrderModel>> GetUserOrdersAsync(int orderId);

        Task<bool> CheckOrderActivityAsync(OrderModel order);

        Task CancelOrderAsync(int orderId);

        Task DeleteOrderAsync(int orderId);
    }
}