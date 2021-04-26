using System.Threading.Tasks;
using CarRentalSystem.View.ViewModels;

namespace CarRentalSystem.Services.Interfaces
{
    public interface IAdminServiceFunctionalityProviderService
    {
        Task<AdditionalServiceViewModel> GetAdditionalServiceAsync(int id);
        Task AddAdditionalServiceAsync(AdditionalServiceViewModel additionalService);
        Task ModifyAdditionalServiceAsync(int id, AdditionalServiceViewModel additionalService);
    }
}