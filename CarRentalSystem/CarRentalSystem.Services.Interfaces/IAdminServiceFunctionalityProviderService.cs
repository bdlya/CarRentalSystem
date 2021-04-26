using CarRentalSystem.Infrastructure.Data.Models;
using System.Threading.Tasks;

namespace CarRentalSystem.Services.Interfaces
{
    public interface IAdminServiceFunctionalityProviderService
    {
        Task<AdditionalServiceModel> GetAdditionalServiceAsync(int id);
        Task AddAdditionalServiceAsync(AdditionalServiceModel additionalService);
        Task ModifyAdditionalServiceAsync(int id, AdditionalServiceModel additionalService);
    }
}