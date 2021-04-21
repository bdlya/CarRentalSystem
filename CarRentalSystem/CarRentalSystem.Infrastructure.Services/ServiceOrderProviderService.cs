using AutoMapper;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;
using CarRentalSystem.View.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.Data.Models;

namespace CarRentalSystem.Infrastructure.Services
{
    public class ServiceOrderProviderService : IServiceOrderProviderService
    {
        private readonly IServiceOrderService _service;
        private readonly IMapper _mapper;

        public ServiceOrderProviderService(IServiceOrderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;

        }

        public async Task<List<AdditionalServiceViewModel>> GetAdditionalServices(int orderId)
        {
            List<AdditionalServiceModel> additionalServices =
                await Task.Run(() => _service.GetAdditionalServices(orderId));

            return additionalServices.Select(service => _mapper.Map<AdditionalServiceViewModel>(service)).ToList();
        }
    }
}