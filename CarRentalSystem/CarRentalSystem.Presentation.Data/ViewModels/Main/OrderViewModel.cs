using CarRentalSystem.Presentation.Data.ViewModels.Base;
using CarRentalSystem.Presentation.Data.ViewModels.Support;
using System;
using System.Collections.Generic;

namespace CarRentalSystem.Presentation.Data.ViewModels.Main
{
    public class OrderViewModel: BaseEntityViewModel
    {
        public UserViewModel CurrentCustomer { get; set; }

        public int? CurrentCustomerId { get; set; }

        public CarViewModel Car { get; set; }

        public int? CarId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public List<OrderAdditionalWorkViewModel> OrderAdditionalWorks { get; set; }

        public int TotalCost { get; set; }

        public OrderViewModel()
        {
            OrderAdditionalWorks = new List<OrderAdditionalWorkViewModel>();
        }
    }
}