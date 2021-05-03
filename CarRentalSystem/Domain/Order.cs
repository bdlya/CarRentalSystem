﻿using System;
using System.Collections.Generic;
using CarRentalSystem.Domain.Entities.Base;

namespace CarRentalSystem.Domain.Entities
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

        public List<OrderAdditionalService> OrderAdditionalServices { get; set; }

        public int TotalCost { get; set; }

        public Order()
        {
            OrderAdditionalServices = new List<OrderAdditionalService>();
        }
    }
}