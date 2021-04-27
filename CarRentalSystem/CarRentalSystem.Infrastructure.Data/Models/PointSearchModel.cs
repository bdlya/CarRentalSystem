using System;

namespace CarRentalSystem.Infrastructure.Data.Models
{
    public class PointSearchModel
    {
        public string Country { get; set; }

        public string City { get; set; }

        public DateTime DateOfOrder { get; set; }
    }
}