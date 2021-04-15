using System.Collections.Generic;
using CarRentalSystem.Domain.Entities.Base;

namespace CarRentalSystem.Domain.Entities
{
    public class AdditionalService : BaseEntity
    {
        public string Name { get; set; }

        public int Cost { get; set; }

        public List<OrderAdditionalService> OrderAdditionalServices { get; set; }
    }
}