using System.Collections.Generic;
using CarRentalSystem.Domain.Entities.Base;

namespace CarRentalSystem.Domain.Entities
{
    public class PointOfRental : BaseEntity
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public List<Car> Cars { get; set; }

        public List<Order> Orders { get; set; }

        public PointOfRental()
        {
            Cars = new List<Car>();
            Orders = new List<Order>();
        }
    }
}