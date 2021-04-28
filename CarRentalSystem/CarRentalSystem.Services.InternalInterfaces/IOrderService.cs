using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.Data.Models;

namespace CarRentalSystem.Services.InternalInterfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(int userId, int carId, BookingDatesModel bookingDates);
    }
}