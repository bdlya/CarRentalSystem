using System;
using CarRentalSystem.Domain.Entities.Base;

namespace CarRentalSystem.Domain.Entities
{
    public class Car: BaseEntity
    {
        public string Brand { get; set; }

        public int NumberOfSeats { get; set; }

        public int AverageFuelConsumption { get; set; }

        public string TransmissionType { get; set; }

        public int CostPerHour { get; set; }

        public Order CurrentOrder { get; set; }

        public int CurrentOrderId { get; set; }

        public PointOfRental PointOfRental { get; set; }

        public int PointOfRentalId { get; set; }
    }
}
