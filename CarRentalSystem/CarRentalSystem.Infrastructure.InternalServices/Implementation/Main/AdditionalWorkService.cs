using AutoMapper;
using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.InternalInterfaces.Main;
using CarRentalSystem.Domain.Entities.Main;
using CarRentalSystem.Domain.Interfaces.Repository;
using CarRentalSystem.Infrastructure.ExceptionHandling.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.InternalServices.Implementation.Main
{
    public class AdditionalWorkService: IAdditionalWorkService
    {
        private readonly ICarRentalSystemRepository<AdditionalWork> _additionalWorkRepository;
        private readonly IMapper _mapper;

        public AdditionalWorkService(ICarRentalSystemRepository<AdditionalWork> additionalWorkRepository, IMapper mapper)
        {
            _additionalWorkRepository = additionalWorkRepository;
            _mapper = mapper;
        }

        public async Task<AdditionalWorkModel> GetAdditionalWorkAsync(int id)
        {
            AdditionalWorkModel additionalService = _mapper.Map<AdditionalWorkModel>(await _additionalWorkRepository.FindByIdAsync(id));

            if (additionalService == null)
            {
                throw new EntityNotFoundException(nameof(AdditionalWork));
            }

            return additionalService;
        }

        public async Task AddAdditionalWorkAsync(AdditionalWorkModel additionalService)
        {
            await _additionalWorkRepository.CreateAsync(_mapper.Map<AdditionalWork>(additionalService));
        }

        public async Task ModifyAdditionalWorkAsync(int id, AdditionalWorkModel additionalService)
        {
            AdditionalWorkModel addService = _mapper.Map<AdditionalWorkModel>(await _additionalWorkRepository.FindByIdAsync(id));

            if (addService == null)
            {
                throw new EntityNotFoundException(nameof(AdditionalWork));
            }

            addService = UpdateAdditionalServiceProperties(addService, additionalService);

            await _additionalWorkRepository.UpdateAsync(_mapper.Map<AdditionalWork>(addService));
        }

        public async Task<List<AdditionalWorkModel>> GetAdditionalWorksAsync(List<int> additionalServiceIds)
        {
            var additionalWorks = await _additionalWorkRepository.GetAsQueryable();

            var additionalWorksModel = additionalWorks.AsEnumerable()
                .Select(work => _mapper.Map<AdditionalWorkModel>(work)).ToList();

            List<AdditionalWorkModel> services = new List<AdditionalWorkModel>();

            foreach (int id in additionalServiceIds)
            {
                services.AddRange(additionalWorksModel.Where(service => service.Id == id));
            }

            return services;
        }

        public async Task<List<AdditionalWorkModel>> GetAdditionalWorksAsync()
        {
            var additionalWorks = await _additionalWorkRepository.GetAsQueryable();

            var additionalWorksModel = additionalWorks.AsEnumerable()
                .Select(work => _mapper.Map<AdditionalWorkModel>(work)).ToList();

            return additionalWorksModel;
        }

        private AdditionalWorkModel UpdateAdditionalServiceProperties(AdditionalWorkModel addService, AdditionalWorkModel additionalService)
        {
            addService.Name = additionalService.Name;
            addService.Cost = additionalService.Cost;

            return addService;
        }
    }
}