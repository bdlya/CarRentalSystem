using System;
using System.Collections.Generic;
using CarRentalSystem.Application.Data.Models.Base;
using CarRentalSystem.Application.Data.Models.Support;

namespace CarRentalSystem.Application.Data.Models.Main
{
    public class OrderModel: BaseEntityModel
    {
        public UserModel CurrentCustomer { get; set; }

        public int? CurrentCustomerId { get; set; }

        public CarModel Car { get; set; }

        public int? CarId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public List<OrderAdditionalWorkModel> OrderAdditionalServices { get; set; }

        public int TotalCost { get; set; }

        public OrderModel()
        {
            OrderAdditionalServices = new List<OrderAdditionalWorkModel>();
        }
    }
}