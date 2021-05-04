using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.Data.Models.Support;

namespace CarRentalSystem.Application.InternalInterfaces.Support
{
    public interface IOrderAdditionalWorkService
    {
        Task<List<OrderAdditionalWorkModel>> CreateOrderAdditionalServicesAsync(int orderId, List<AdditionalWorkModel> additionalServices);
    }
}