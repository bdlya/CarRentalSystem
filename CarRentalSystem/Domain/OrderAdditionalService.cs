using CarRentalSystem.Domain.Entities.Base;

namespace CarRentalSystem.Domain.Entities
{
    public class OrderAdditionalService: BaseEntity
    {
        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int AdditionalServiceId { get; set; }

        public AdditionalService AdditionalService { get; set; }
    }
}