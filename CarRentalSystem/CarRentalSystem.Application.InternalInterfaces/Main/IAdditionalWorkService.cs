using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalSystem.Application.Data.Models.Main;

namespace CarRentalSystem.Application.InternalInterfaces.Main
{
    public interface IAdditionalWorkService
    {
        Task<AdditionalWorkModel> GetAdditionalWorkAsync(int id);

        Task AddAdditionalWorkAsync(AdditionalWorkModel additionalService);

        Task ModifyAdditionalWorkAsync(int id, AdditionalWorkModel additionalService);

        Task<List<AdditionalWorkModel>> GetAdditionalWorksAsync(List<int> additionalServiceIds);

        Task<List<AdditionalWorkModel>> GetAdditionalWorksAsync();
    }
}