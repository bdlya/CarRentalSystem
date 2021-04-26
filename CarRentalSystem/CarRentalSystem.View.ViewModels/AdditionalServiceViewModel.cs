using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CarRentalSystem.View.ViewModels.Base;
using CarRentalSystem.View.ViewModels.Validation;

namespace CarRentalSystem.View.ViewModels
{
    [AdditionalServiceValidation]
    public class AdditionalServiceViewModel: BaseEntityViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Cost { get; set; }

        public List<OrderAdditionalServiceViewModel> OrderAdditionalServices { get; set; }

        public AdditionalServiceViewModel()
        {
            OrderAdditionalServices = new List<OrderAdditionalServiceViewModel>();
        }
    }
}