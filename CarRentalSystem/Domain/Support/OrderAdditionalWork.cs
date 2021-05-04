using CarRentalSystem.Domain.Entities.Base;
using CarRentalSystem.Domain.Entities.Main;

namespace CarRentalSystem.Domain.Entities.Support
{
    public class OrderAdditionalWork: BaseEntity
    {
        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int AdditionalServiceId { get; set; }

        public AdditionalWork AdditionalService { get; set; }
    }
}