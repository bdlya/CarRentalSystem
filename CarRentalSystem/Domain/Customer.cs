using System.Collections.Generic;
using CarRentalSystem.Domain.Entities.Base;

namespace CarRentalSystem.Domain.Entities
{
    public class Customer: BaseEntity
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public List<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
        }
    }
}