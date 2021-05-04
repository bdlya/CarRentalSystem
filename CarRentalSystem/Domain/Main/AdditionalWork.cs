using System.Collections.Generic;
using CarRentalSystem.Domain.Entities.Base;
using CarRentalSystem.Domain.Entities.Support;

namespace CarRentalSystem.Domain.Entities.Main
{
    public class AdditionalWork : BaseEntity
    {
        public string Name { get; set; }

        public int Cost { get; set; }

        public List<OrderAdditionalWork> OrderAdditionalWorks { get; set; }

        public AdditionalWork()
        {
            OrderAdditionalWorks = new List<OrderAdditionalWork>();
        }
    }
}