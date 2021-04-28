using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.Data.Models;

namespace CarRentalSystem.Services.Interfaces
{
    public interface IBookingProviderService
    {
        Task ChooseDatesAsync(int userId, int carId, BookingDatesModel bookingDates);
    }
}