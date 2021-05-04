﻿using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.Data.Models.Support;
using CarRentalSystem.Application.ExternalServices.Interfaces.User;
using CarRentalSystem.Application.InternalServices.Interfaces.Main;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalSystem.Application.InternalServices.Interfaces.Support;

namespace CarRentalSystem.Application.ExternalServices.Implementation.User
{
    public class BookingProviderService: IBookingProviderService
    {
        private readonly IOrderService _orderService;
        private readonly IAdditionalWorkService _additionalService;
        private readonly IOrderAdditionalWorkService _orderAdditionalService;

        public BookingProviderService(IOrderService orderService, IAdditionalWorkService additionalService, IOrderAdditionalWorkService orderAdditionalService)
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
                var additionalServices = await _additionalService.GetAdditionalWorksAsync(additionalServicesIds);

                var orderAdditionalServices = await _orderAdditionalService.CreateOrderAdditionalServicesAsync(orderId, additionalServices);

                await _orderService.AddAdditionalServicesAsync(orderId, orderAdditionalServices);
            }
        }

        public async Task<OrderModel> GetSummaryAsync(int orderId)
        {
            return await _orderService.GetOrderAsync(orderId);
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            await _orderService.DeleteOrderAsync(orderId);
        }
    }
}