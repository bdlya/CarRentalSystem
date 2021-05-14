using System;
using System.Collections.Generic;

namespace CarRentalSystem.Application.Data.Models.Support
{
    public class OrderCreationModel
    {
        public int CustomerId { get; set; }

        public int CarId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<int> AdditionalServicesIds { get; set; }
    }
}