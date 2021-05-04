using CarRentalSystem.Presentation.Data.ViewModels.Base;
using CarRentalSystem.Presentation.Data.ViewModels.Support;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Presentation.Data.ViewModels.Main
{
    public class AdditionalWorkViewModel: BaseEntityViewModel
    {
        [Required(ErrorMessage = "Enter name")]
        [MinLength(3, ErrorMessage = "Name should be at least three symbols long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter cost")]
        [Range(100, 600, ErrorMessage = "Cost should be in range from 100 to 600")]
        public int Cost { get; set; }

        public List<OrderAdditionalWorkViewModel> OrderAdditionalWorks { get; set; }

        public AdditionalWorkViewModel()
        {
            OrderAdditionalWorks = new List<OrderAdditionalWorkViewModel>();
        }
    }
}