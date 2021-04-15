using System.Text;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;

namespace CarRentalSystem.Infrastructure.Services
{
    public class OrderProviderService : IOrderProviderService
    {
        private readonly IOrderService _service;

        public OrderProviderService(IOrderService service)
        {
            _service = service;
        }
        public string GetAdditionalServices(int orderId)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var service in _service.GetAdditionalServices(orderId))
            {
                builder.Append(service.Name);
            }

            return builder.ToString();
        }
    }
}