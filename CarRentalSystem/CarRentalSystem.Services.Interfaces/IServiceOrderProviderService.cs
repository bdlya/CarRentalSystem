using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalSystem.View.ViewModels;

namespace CarRentalSystem.Services.Interfaces
{
    public interface IServiceOrderProviderService
    {
        Task<List<AdditionalServiceViewModel>> GetAdditionalServices(int orderId);
    }
}