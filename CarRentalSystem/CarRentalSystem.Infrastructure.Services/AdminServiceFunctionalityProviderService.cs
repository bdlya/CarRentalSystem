using System.Threading.Tasks;
using AutoMapper;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;
using CarRentalSystem.View.ViewModels;

namespace CarRentalSystem.Infrastructure.Services
{
    public class AdminServiceFunctionalityProviderService: IAdminServiceFunctionalityProviderService
    {
        private readonly IAdditionalService _additionalService;
        private readonly IMapper _mapper;

        public AdminServiceFunctionalityProviderService(IAdditionalService additionalService, IMapper mapper)
        {
            _additionalService = additionalService;
            _mapper = mapper;
        }

        public async Task<AdditionalServiceViewModel> GetAdditionalServiceAsync(int id)
        {
            AdditionalServiceModel additionalService = await _additionalService.GetAdditionalServiceAsync(id);

            return _mapper.Map<AdditionalServiceViewModel>(additionalService);
        }

        public async Task AddAdditionalServiceAsync(AdditionalServiceViewModel additionalService)
        {
            await _additionalService.AddAdditionalServiceAsync(_mapper.Map<AdditionalServiceModel>(additionalService));
        }

        public async Task ModifyAdditionalServiceAsync(int id, AdditionalServiceViewModel additionalService)
        {
            await _additionalService.ModifyAdditionalServiceAsync(id,
                _mapper.Map<AdditionalServiceModel>(additionalService));
        }
    }
}