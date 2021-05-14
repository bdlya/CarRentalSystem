using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.Data.Models.Support;
using CarRentalSystem.Application.ExternalInterfaces.User;
using CarRentalSystem.Application.InternalInterfaces.Main;
using CarRentalSystem.Application.InternalInterfaces.Support;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<OrderModel> GetSummaryAsync(OrderCreationModel order)
        {
            OrderModel orderSummary = await _orderService.CreateOrderAsync(order);

            if (order.AdditionalServicesIds.Count != 0)
            {
                orderSummary = await AddAdditionalServices(orderSummary, order.AdditionalServicesIds);
            }

            orderSummary.TotalCost = _orderService.CountOrderTotalCost(orderSummary);

            return orderSummary;
        }

        public async Task<List<AdditionalWorkModel>> GetAdditionalWorks()
        {
            return await _additionalService.GetAdditionalWorksAsync();
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            await _orderService.DeleteOrderAsync(orderId);
        }

        private async Task<OrderModel> AddAdditionalServices(OrderModel orderSummary, List<int> additionalServicesIds)
        {
            var additionalServices = await _additionalService.GetAdditionalWorksAsync(additionalServicesIds);

            var orderAdditionalServices =  await _orderAdditionalService.CreateOrderAdditionalServicesAsync(orderSummary.Id, additionalServices);

            orderSummary.OrderAdditionalServices.AddRange(orderAdditionalServices);

            return orderSummary;
        }
    }
}