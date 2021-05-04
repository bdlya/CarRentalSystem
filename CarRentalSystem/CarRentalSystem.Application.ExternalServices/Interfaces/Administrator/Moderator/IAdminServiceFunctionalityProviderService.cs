using CarRentalSystem.Application.Data.Models.Main;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.ExternalServices.Interfaces.Administrator.Moderator
{
    public interface IAdminServiceFunctionalityProviderService
    {
        Task<AdditionalWorkModel> GetAdditionalWorkAsync(int id);
        Task AddAdditionalWorkAsync(AdditionalWorkModel additionalService);
        Task ModifyAdditionalWorkAsync(int id, AdditionalWorkModel additionalService);
    }
}