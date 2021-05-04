using System.Collections.Generic;
using CarRentalSystem.Application.Data.Models.Base;

namespace CarRentalSystem.Application.Data.Models.Main
{
    public class PointOfRentalModel: BaseEntityModel
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public List<CarModel> Cars { get; set; }

        public PointOfRentalModel()
        {
            Cars = new List<CarModel>();
        }
    }
}