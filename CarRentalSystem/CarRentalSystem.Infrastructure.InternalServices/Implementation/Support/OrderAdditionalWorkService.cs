using AutoMapper;
using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.Data.Models.Support;
using CarRentalSystem.Application.InternalServices.Interfaces.Support;
using CarRentalSystem.Domain.Entities.Support;
using CarRentalSystem.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.InternalServices.Implementation.Support
{
    public class OrderAdditionalWorkService: IOrderAdditionalWorkService
    {
        private readonly ICarRentalSystemRepository<OrderAdditionalWork> _repository;
        private readonly IMapper _mapper;

        public OrderAdditionalWorkService(ICarRentalSystemRepository<OrderAdditionalWork> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<OrderAdditionalWorkModel>> CreateOrderAdditionalServicesAsync(int orderId, List<AdditionalWorkModel> additionalWorks)
        {
            List<OrderAdditionalWorkModel> orderAdditionalWorks = new List<OrderAdditionalWorkModel>();

            foreach (var service in additionalWorks)
            {
                var orderAdditionalWork = new OrderAdditionalWorkModel
                {
                    OrderId = orderId,
                    AdditionalWorkId = service.Id
                };

                await _repository.CreateAsync(_mapper.Map<OrderAdditionalWork>(orderAdditionalWork));

                orderAdditionalWorks.Add(orderAdditionalWork);
            }

            return orderAdditionalWorks;
        }
    }
}