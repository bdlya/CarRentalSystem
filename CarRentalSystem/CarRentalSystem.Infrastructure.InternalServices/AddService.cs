using System;
using System.Threading.Tasks;
using AutoMapper;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Interfaces;
using CarRentalSystem.Infrastructure.Data.Models;
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
            AdditionalService additionalService = await _repository.FindById(id);

            if (additionalService == null)
            {
                throw new NullReferenceException();
            }

            return _mapper.Map<AdditionalServiceModel>(additionalService);
        }

        public async Task AddAdditionalServiceAsync(AdditionalServiceModel additionalService)
        {
            await _repository.Create(_mapper.Map<AdditionalService>(additionalService));
        }

        public async Task ModifyAdditionalServiceAsync(int id, AdditionalServiceModel additionalService)
        {
            AdditionalService addService = await _repository.FindById(id);

            if (addService == null)
            {
                throw new NullReferenceException();
            }

            addService = UpdateAdditionalServiceProperties(addService, _mapper.Map<AdditionalService>(additionalService));

            await _repository.Update(addService);
        }

        private AdditionalService UpdateAdditionalServiceProperties(AdditionalService addService, AdditionalService additionalService)
        {
            addService.Name = additionalService.Name;
            addService.Cost = additionalService.Cost;

            return addService;
        }
    }
}