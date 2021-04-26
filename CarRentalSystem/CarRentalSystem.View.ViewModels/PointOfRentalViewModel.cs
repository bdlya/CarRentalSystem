using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CarRentalSystem.View.ViewModels.Base;

namespace CarRentalSystem.View.ViewModels
{
    public class PointOfRentalViewModel: BaseEntityViewModel
    {
        [Required(ErrorMessage = "Enter name")]
        [MinLength(3, ErrorMessage = "Name should be at least three symbols long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter country")]
        [MinLength(3, ErrorMessage = "Country should be at least three symbols long")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Enter city")]
        [MinLength(3, ErrorMessage = "City should be at least three symbols long")]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter address")]
        [MinLength(3, ErrorMessage = "Address should be at least three symbols long")]
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