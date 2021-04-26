using System;
using System.Threading.Tasks;
using AutoMapper;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Interfaces;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Infrastructure.ExceptionHandling.Exceptions;
using CarRentalSystem.Services.InternalInterfaces;

namespace CarRentalSystem.Infrastructure.InternalServices
{
    public class AddService: IAdditionalService
    {
        private readonly IRentalRepository<AdditionalService> _repository;
        private readonly IMapper _mapper;

        public AddService(IRentalRepository<AdditionalService> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AdditionalServiceModel> GetAdditionalServiceAsync(int id)
        {
            AdditionalServiceModel additionalService = _mapper.Map<AdditionalServiceModel>(await _repository.FindByIdAsync(id));

            if (additionalService == null)
            {
                throw new IdNotFoundException();
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
                throw new IdNotFoundException();
            }

            addService = UpdateAdditionalServiceProperties(addService, additionalService);

            await _repository.UpdateAsync(_mapper.Map<AdditionalService>(addService));
        }

        private AdditionalServiceModel UpdateAdditionalServiceProperties(AdditionalServiceModel addService, AdditionalServiceModel additionalService)
        {
            addService.Name = additionalService.Name;
            addService.Cost = additionalService.Cost;

            return addService;
        }
    }
}