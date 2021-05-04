using System;
using System.Collections.Generic;
using CarRentalSystem.Domain.Entities.Base;
using CarRentalSystem.Domain.Entities.Support;

namespace CarRentalSystem.Domain.Entities.Main
{
    public class Order : BaseEntity
    {
        public User CurrentCustomer { get; set; }

        public int? CurrentCustomerId { get; set; }

        public Car Car { get; set; }

        public int? CarId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public List<OrderAdditionalWork> OrderAdditionalWorks { get; set; }

        public int TotalCost { get; set; }

        public Order()
        {
            OrderAdditionalWorks = new List<OrderAdditionalWork>();
        }
    }
}