using CarRentalSystem.Infrastructure.Data.Models.Base;

namespace CarRentalSystem.Infrastructure.Data.Models
{
    public class OrderAdditionalServiceModel: BaseEntityModel
    {
        public int OrderId { get; set; }

        public OrderModel Order { get; set; }

        public int AdditionalServiceId { get; set; }

        public AdditionalServiceModel AdditionalService { get; set; }
    }
}