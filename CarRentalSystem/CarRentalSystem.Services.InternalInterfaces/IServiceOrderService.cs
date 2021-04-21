using CarRentalSystem.Infrastructure.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalSystem.Services.InternalInterfaces
{
    public interface IServiceOrderService
    {
        Task<List<AdditionalServiceModel>> GetAdditionalServices(int orderId);
    }
}