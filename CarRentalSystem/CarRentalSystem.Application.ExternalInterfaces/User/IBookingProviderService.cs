using System.Collections.Generic;
using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.Data.Models.Support;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.ExternalInterfaces.User
{
    public interface IBookingProviderService
    {
        Task<OrderModel> GetSummaryAsync(OrderCreationModel order);

        Task<List<AdditionalWorkModel>> GetAdditionalWorks();

        Task DeleteOrderAsync(int orderId);
    }
}