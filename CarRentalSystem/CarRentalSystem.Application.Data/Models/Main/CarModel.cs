using CarRentalSystem.Application.Data.Models.Base;

namespace CarRentalSystem.Application.Data.Models.Main
{
    public class CarModel: BaseEntityModel
    {
        public string Brand { get; set; }

        public int NumberOfSeats { get; set; }

        public int AverageFuelConsumption { get; set; }

        public string TransmissionType { get; set; }

        public int CostPerHour { get; set; }

        public OrderModel CurrentOrder { get; set; }

        public int? CurrentOrderId { get; set; }

        public PointOfRentalModel PointOfRental { get; set; }

        public int PointOfRentalId { get; set; }
    }
}