using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CarRentalSystem.View.ViewModels.Base;

namespace CarRentalSystem.View.ViewModels
{
    public class AdditionalServiceViewModel: BaseEntityViewModel
    {
        [Required(ErrorMessage = "Enter name")]
        [MinLength(3, ErrorMessage = "Name should be at least three symbols long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter cost")]
        [Range(100, 600, ErrorMessage = "Cost should be in range from 100 to 600")]
        public int Cost { get; set; }

        public List<OrderAdditionalServiceViewModel> OrderAdditionalServices { get; set; }

        public AdditionalServiceViewModel()
        {
            OrderAdditionalServices = new List<OrderAdditionalServiceViewModel>();
        }
    }
}