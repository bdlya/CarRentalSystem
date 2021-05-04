using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.ExternalInterfaces.Administrator.Moderator;
using CarRentalSystem.Application.InternalInterfaces.Main;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.ExternalServices.Implementation.Administrator.Moderator
{
    public class AdminWorkFunctionalityProviderService: IAdminServiceFunctionalityProviderService
    {
        private readonly IAdditionalWorkService _additionalService;

        public AdminWorkFunctionalityProviderService(IAdditionalWorkService additionalService)
        {
            _additionalService = additionalService;
        }

        public async Task<AdditionalWorkModel> GetAdditionalWorkAsync(int id)
        {
            return await _additionalService.GetAdditionalWorkAsync(id);
        }

        public async Task AddAdditionalWorkAsync(AdditionalWorkModel additionalService)
        {
            await _additionalService.AddAdditionalWorkAsync(additionalService);
        }

        public async Task ModifyAdditionalWorkAsync(int id, AdditionalWorkModel additionalService)
        {
            await _additionalService.ModifyAdditionalWorkAsync(id, additionalService);
        }
    }
}