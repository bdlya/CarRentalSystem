using System.Collections.Generic;
using CarRentalSystem.Infrastructure.Data.Models.Base;

namespace CarRentalSystem.Infrastructure.Data.Models
{
    public class PointOfRentalModel: BaseEntityModel
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public List<CarModel> Cars { get; set; }

        public List<OrderModel> Orders { get; set; }

        public PointOfRentalModel()
        {
            Cars = new List<CarModel>();
            Orders = new List<OrderModel>();
        }
    }
}