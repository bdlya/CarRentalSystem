using System.Collections.Generic;
using CarRentalSystem.Application.Data.Models.Base;
using CarRentalSystem.Application.Data.Models.Support;

namespace CarRentalSystem.Application.Data.Models.Main
{
    public class AdditionalWorkModel: BaseEntityModel
    {
        public string Name { get; set; }

        public int Cost { get; set; }

        public List<OrderAdditionalWorkModel> OrderAdditionalWorks { get; set; }

        public AdditionalWorkModel()
        {
            OrderAdditionalWorks = new List<OrderAdditionalWorkModel>();
        }
    }
}