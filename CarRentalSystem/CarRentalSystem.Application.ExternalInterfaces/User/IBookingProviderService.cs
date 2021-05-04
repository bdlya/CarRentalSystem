using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.Data.Models.Support;

namespace CarRentalSystem.Application.ExternalInterfaces.User
{
    public interface IBookingProviderService
    {
        Task<OrderModel> CreateOrderAsync(int userId, int carId);
        Task ChooseDatesAsync(int orderId, BookingDatesModel bookingDates);
        Task ChooseAdditionalServicesAsync(int orderId, List<int> additionalServicesIds);
        Task<OrderModel> GetSummaryAsync(int orderId);
        Task DeleteOrderAsync(int orderId);
    }
}