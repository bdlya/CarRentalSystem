using System.Collections.Generic;
using CarRentalSystem.Infrastructure.Data.Models.Base;

namespace CarRentalSystem.Infrastructure.Data.Models
{
    public class CustomerModel: BaseEntityModel
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public List<OrderModel> Orders { get; set; }

        public CustomerModel()
        {
            Orders = new List<OrderModel>();
        }
    }
}