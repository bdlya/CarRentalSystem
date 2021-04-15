using System.Collections.Generic;
using CarRentalSystem.View.ViewModels.Base;

namespace CarRentalSystem.View.ViewModels
{
    public class CustomerViewModel: BaseEntityViewModel
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public List<OrderViewModel> Orders { get; set; }
    }
}