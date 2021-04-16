using System.Collections.Generic;
using CarRentalSystem.View.ViewModels.Base;

namespace CarRentalSystem.View.ViewModels
{
    public class PointOfRentalViewModel: BaseEntityViewModel
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public List<CarViewModel> Cars { get; set; }

        public List<OrderViewModel> Orders { get; set; }

        public PointOfRentalViewModel()
        {
            Cars = new List<CarViewModel>();
            Orders = new List<OrderViewModel>();
        }
    }
}