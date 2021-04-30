using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.Data.Models;

namespace CarRentalSystem.Services.InternalInterfaces
{
    public interface IOrderAdditionalService
    {
        Task<List<OrderAdditionalServiceModel>> CreateOrderAdditionalServicesAsync(int orderId, List<AdditionalServiceModel> additionalServices);
    }
}