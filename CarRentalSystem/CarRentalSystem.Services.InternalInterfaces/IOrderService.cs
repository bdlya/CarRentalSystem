using System.Collections.Generic;
using CarRentalSystem.Domain.Entities;

namespace CarRentalSystem.Services.InternalInterfaces
{
    public interface IOrderService
    {
        List<AdditionalService> GetAdditionalServices(int orderId);
    }
}