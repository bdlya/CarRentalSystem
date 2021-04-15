using System.Collections.Generic;
using CarRentalSystem.Infrastructure.Data.Models.Base;

namespace CarRentalSystem.Infrastructure.Data.Models
{
    public class AdditionalServiceModel: BaseEntityModel
    {
        public string Name { get; set; }

        public int Cost { get; set; }

        public List<OrderAdditionalServiceModel> OrderAdditionalServices { get; set; }
    }
}