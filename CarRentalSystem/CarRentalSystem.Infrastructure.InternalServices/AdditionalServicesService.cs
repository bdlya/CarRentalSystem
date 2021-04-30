using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Interfaces;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Infrastructure.ExceptionHandling.Exceptions;
using CarRentalSystem.Services.InternalInterfaces;
using System.Threading.Tasks;

namespace CarRentalSystem.Infrastructure.InternalServices
{
    public class AdditionalServicesService: IAdditionalService
    {
        private readonly IRentalRepository<AdditionalService> _repository;
        private readonly IMapper _mapper;

        public AdditionalServicesService(IRentalRepository<AdditionalService> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AdditionalServiceModel> GetAdditionalServiceAsync(int id)
        {
            AdditionalServiceModel additionalService = _mapper.Map<AdditionalServiceModel>(await _repository.FindByIdAsync(id));

            if (additionalService == null)
            {
                throw new EntityNotFoundException(nameof(AdditionalService));
            }

            return additionalService;
        }

        public async Task AddAdditionalServiceAsync(AdditionalServiceModel additionalService)
        {
            await _repository.CreateAsync(_mapper.Map<AdditionalService>(additionalService));
        }

        public async Task ModifyAdditionalServiceAsync(int id, AdditionalServiceModel additionalService)
        {
            AdditionalServiceModel addService = _mapper.Map<AdditionalServiceModel>(await _repository.FindByIdAsync(id));

            if (addService == null)
            {
                throw new EntityNotFoundException(nameof(AdditionalService));
            }

            addService = UpdateAdditionalServiceProperties(addService, additionalService);

            await _repository.UpdateAsync(_mapper.Map<AdditionalService>(addService));
        }

        public async Task<List<AdditionalServiceModel>> GetAdditionalServicesAsync(List<int> additionalServiceIds)
        {
            var additionalServicesModel = await _repository.GetAsQueryable();

            var additionalServices = additionalServicesModel.AsEnumerable()
                .Select(service => _mapper.Map<AdditionalServiceModel>(service)).ToList();

            List<AdditionalServiceModel> services = new List<AdditionalServiceModel>();

            foreach (int id in additionalServiceIds)
            {
                services.AddRange(additionalServices.Where(service => service.Id == id));
            }

            return services;
        }

        private AdditionalServiceModel UpdateAdditionalServiceProperties(AdditionalServiceModel addService, AdditionalServiceModel additionalService)
        {
            addService.Name = additionalService.Name;
            addService.Cost = additionalService.Cost;

            return addService;
        }
    }
}