using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;
using System.Threading.Tasks;

namespace CarRentalSystem.Infrastructure.Services
{
    public class AdminServiceFunctionalityProviderService: IAdminServiceFunctionalityProviderService
    {
        private readonly IAdditionalService _additionalService;

        public AdminServiceFunctionalityProviderService(IAdditionalService additionalService)
        {
            _additionalService = additionalService;
        }

        public async Task<AdditionalServiceModel> GetAdditionalServiceAsync(int id)
        {
            return await _additionalService.GetAdditionalServiceAsync(id);
        }

        public async Task AddAdditionalServiceAsync(AdditionalServiceModel additionalService)
        {
            await _additionalService.AddAdditionalServiceAsync(additionalService);
        }

        public async Task ModifyAdditionalServiceAsync(int id, AdditionalServiceModel additionalService)
        {
            await _additionalService.ModifyAdditionalServiceAsync(id, additionalService);
        }
    }
}