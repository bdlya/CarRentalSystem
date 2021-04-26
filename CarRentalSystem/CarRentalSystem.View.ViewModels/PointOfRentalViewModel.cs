using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CarRentalSystem.View.ViewModels.Base;
using CarRentalSystem.View.ViewModels.Validation;

namespace CarRentalSystem.View.ViewModels
{
    [PointOfRentalValidation]
    public class PointOfRentalViewModel: BaseEntityViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
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