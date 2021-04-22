using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Interfaces;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.InternalInterfaces;

namespace CarRentalSystem.Infrastructure.InternalServices
{
    public class ServiceOrderService: IServiceOrderService
    {
        private readonly IRentalRepository<OrderAdditionalService> _repository;
        private readonly IMapper _mapper;

        public ServiceOrderService(IRentalRepository<OrderAdditionalService> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AdditionalServiceModel>> GetAdditionalServices(int orderId)
        {
            return await Task.Run(() => _repository
                .Include(order => order.Order)
                .Where(id => id.OrderId == orderId)
                .Select(service => service.AdditionalService)
                .Select(service => _mapper.Map<AdditionalServiceModel>(service))
                .ToList());
        }
    }
}