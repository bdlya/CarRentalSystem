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
        private readonly IOrderAdditionalService _orderAdditionalService;

        public BookingProviderService(IOrderService orderService, IAdditionalService additionalService, IOrderAdditionalService orderAdditionalService)
        {
            _orderService = orderService;
            _additionalService = additionalService;
            _orderAdditionalService = orderAdditionalService;
        }
        public async Task<OrderModel> CreateOrderAsync(int userId, int carId)
        {
            return await _orderService.CreateOrderAsync(userId, carId);
        }

        public async Task ChooseDatesAsync(int orderId, BookingDatesModel bookingDates)
        { 
            await _orderService.ChooseDatesAsync(orderId, bookingDates);
        }

        public async Task ChooseAdditionalServicesAsync(int orderId, List<int> additionalServicesIds)
        {
            if (additionalServicesIds.Count != 0)
            {
                var additionalServices = await _additionalService.GetAdditionalServicesAsync(additionalServicesIds);

                var orderAdditionalServices = await _orderAdditionalService.CreateOrderAdditionalServicesAsync(orderId, additionalServices);

                await _orderService.AddAdditionalServicesAsync(orderId, orderAdditionalServices);
            }
        }

        public async Task<OrderModel> GetSummaryAsync(int orderId)
        {
            return await _orderService.GetOrderAsync(orderId);
        }
    }
}