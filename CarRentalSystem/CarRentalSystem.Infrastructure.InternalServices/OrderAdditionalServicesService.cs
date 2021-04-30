using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Interfaces;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.InternalInterfaces;

namespace CarRentalSystem.Infrastructure.InternalServices
{
    public class OrderAdditionalServicesService: IOrderAdditionalService
    {
        private readonly IRentalRepository<OrderAdditionalService> _repository;
        private readonly IMapper _mapper;

        public OrderAdditionalServicesService(IRentalRepository<OrderAdditionalService> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<OrderAdditionalServiceModel>> CreateOrderAdditionalServicesAsync(int orderId, List<AdditionalServiceModel> additionalServices)
        {
            List<OrderAdditionalServiceModel> orderAdditionalServices = new List<OrderAdditionalServiceModel>();

            foreach (var service in additionalServices)
            {
                var orderAdditionalService = new OrderAdditionalServiceModel
                {
                    OrderId = orderId,
                    AdditionalServiceId = service.Id
                };

                await _repository.CreateAsync(_mapper.Map<OrderAdditionalService>(orderAdditionalService));

                orderAdditionalServices.Add(orderAdditionalService);
            }

            return orderAdditionalServices;
        }
    }
}