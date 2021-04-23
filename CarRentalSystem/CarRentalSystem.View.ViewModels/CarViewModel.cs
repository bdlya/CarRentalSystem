using System.ComponentModel.DataAnnotations;
using CarRentalSystem.View.ViewModels.Base;
using CarRentalSystem.View.ViewModels.Validation;

namespace CarRentalSystem.View.ViewModels
{
    [CarValidation]
    public class CarViewModel: BaseEntityViewModel
    {
        [Required]
        public string Brand { get; set; }

        [Required]
        public int NumberOfSeats { get; set; }

        [Required]
        public int AverageFuelConsumption { get; set; }

        [Required]
        public string TransmissionType { get; set; }

        [Required]
        public int CostPerHour { get; set; }

        public OrderViewModel CurrentOrder { get; set; }

        public int? CurrentOrderId { get; set; }

        public PointOfRentalViewModel PointOfRental { get; set; }

        [Required]
        public int PointOfRentalId { get; set; }
    }
}