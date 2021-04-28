using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;

namespace CarRentalSystem.Infrastructure.Services
{
    public class BookingProviderService: IBookingProviderService
    {
        private readonly IOrderService _orderService;

        public BookingProviderService(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task ChooseDatesAsync(int userId, int carId, BookingDatesModel bookingDates)
        { 
            await _orderService.CreateOrderAsync(userId, carId, bookingDates);
        }
    }
}