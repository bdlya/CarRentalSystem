﻿using CarRentalSystem.Presentation.Data.ViewModels.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Presentation.Data.ViewModels.Main
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

        public int CarCount => Cars.Count;

        public PointOfRentalViewModel()
        {
            Cars = new List<CarViewModel>();
        }
    }
}