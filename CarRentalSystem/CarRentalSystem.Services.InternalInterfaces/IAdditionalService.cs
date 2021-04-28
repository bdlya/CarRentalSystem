using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.Data.Models;

namespace CarRentalSystem.Services.InternalInterfaces
{
    public interface IAdditionalService
    {
        Task<AdditionalServiceModel> GetAdditionalServiceAsync(int id);
        Task AddAdditionalServiceAsync(AdditionalServiceModel additionalService);
        Task ModifyAdditionalServiceAsync(int id, AdditionalServiceModel additionalService);
        Task<List<AdditionalServiceModel>> GetAdditionalServicesAsync(List<int> additionalServiceIds);
    }
}