using System.Collections.Generic;
using CarRentalSystem.View.ViewModels.Base;

namespace CarRentalSystem.View.ViewModels
{
    public class AdditionalServiceViewModel: BaseEntityViewModel
    {
        public string Name { get; set; }

        public int Cost { get; set; }

        public List<OrderAdditionalServiceViewModel> OrderAdditionalServices { get; set; }
    }
}