using System.Collections.Generic;
using CarRentalSystem.Domain.Entities;

namespace CarRentalSystem.Services.InternalInterfaces
{
    public interface IServiceOrderService
    {
        List<AdditionalService> GetAdditionalServices(int orderId);
    }
}