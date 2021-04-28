using System;
using System.Collections.Generic;
using CarRentalSystem.View.ViewModels.Base;

namespace CarRentalSystem.View.ViewModels
{
    public class OrderViewModel: BaseEntityViewModel
    {
        public UserViewModel CurrentCustomer { get; set; }

        public int? CurrentCustomerId { get; set; }

        public CarViewModel Car { get; set; }

        public int? CarId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<OrderAdditionalServiceViewModel> OrderAdditionalServices { get; set; }

        public int TotalCost { get; set; }

        public OrderViewModel()
        {
            OrderAdditionalServices = new List<OrderAdditionalServiceViewModel>();
        }
    }
}