using CarRentalSystem.View.ViewModels.Base;

namespace CarRentalSystem.View.ViewModels
{
    public class CarViewModel: BaseEntityViewModel
    {
        public string Brand { get; set; }

        public int NumberOfSeats { get; set; }

        public int AverageFuelConsumption { get; set; }

        public string TransmissionType { get; set; }

        public int CostPerHour { get; set; }

        public OrderViewModel CurrentOrder { get; set; }

        public int? CurrentOrderId { get; set; }

        public PointOfRentalViewModel PointOfRental { get; set; }

        public int PointOfRentalId { get; set; }
    }
}