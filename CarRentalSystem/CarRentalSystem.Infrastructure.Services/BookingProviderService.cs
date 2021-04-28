using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;

namespace CarRentalSystem.Infrastructure.Services
{
    public class BookingProviderService: IBookingProviderService
    {
        private readonly IOrderService _orderService;
        private readonly IAdditionalService _additionalService;

        public BookingProviderService(IOrderService orderService, IAdditionalService additionalService)
        {
            _orderService = orderService;
            _additionalService = additionalService;
        }

        public async Task ChooseDatesAsync(int userId, int carId, BookingDatesModel bookingDates)
        { 
            await _orderService.CreateOrderAsync(userId, carId, bookingDates);
        }

        public async Task ChooseAdditionalServicesAsync(int carId, List<int> additionalServicesIds)
        {
            if (additionalServicesIds.Count != 0)
            {
                List<AdditionalServiceModel> additionalServices = await _additionalService.GetAdditionalServicesAsync(additionalServicesIds);

                await _orderService.AddAdditionalServicesAsync(carId, additionalServices);
            }
        }

        public async Task<OrderModel> GetSummaryAsync(int carId)
        {
            return await _orderService.GetOrderAsync(carId);
        }
    }
}