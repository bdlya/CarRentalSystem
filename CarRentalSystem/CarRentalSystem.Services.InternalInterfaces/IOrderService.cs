using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.Data.Models;

namespace CarRentalSystem.Services.InternalInterfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(int userId, int carId, BookingDatesModel bookingDates);
        Task AddAdditionalServicesAsync(int carId, List<AdditionalServiceModel> additionalServices);
        Task<OrderModel> GetOrderAsync(int carId);
    }
}