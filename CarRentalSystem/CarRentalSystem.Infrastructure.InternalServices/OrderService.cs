using System.Collections.Generic;
using System.Linq;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;

namespace CarRentalSystem.Infrastructure.InternalServices
{
    public class OrderService: IOrderService
    {
        private readonly IRentalRepository<OrderAdditionalService> _repository;

        public OrderService(IRentalRepository<OrderAdditionalService> repository)
        {
            _repository = repository;
        }

        public List<AdditionalService> GetAdditionalServices(int orderId)
        {
            return _repository
                .Include(order => order.Order)
                .Where(id => id.OrderId == orderId)
                .Select(service => service.AdditionalService).ToList();
        }
    }
}