using System.Text;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;

namespace CarRentalSystem.Infrastructure.Services
{
    public class ServiceOrderProviderService : IServiceOrderProviderService
    {
        private readonly IServiceOrderService _service;

        public ServiceOrderProviderService(IServiceOrderService service)
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