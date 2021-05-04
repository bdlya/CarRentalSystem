using CarRentalSystem.Presentation.Data.ViewModels.Base;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarRentalSystem.Presentation.Data.ViewModels.Main
{
    public class CarViewModel: BaseEntityViewModel
    {
        [Required(ErrorMessage = "Enter brand")]
        [MinLength(3, ErrorMessage = "Brand should be at least three symbols long")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Enter number of seats")]
        [Range(2, 10, ErrorMessage = "Number of seats should be in range from 2 to 10")]
        public int NumberOfSeats { get; set; }

        [Required(ErrorMessage = "Enter average fuel consumption")]
        [Range(10, 100, ErrorMessage = "Average fuel consumption should be in range from 10 to 100")]
        public int AverageFuelConsumption { get; set; }

        [Required(ErrorMessage = "Enter transmission type")]
        public string TransmissionType { get; set; }

        [Required(ErrorMessage = "Enter cost per hour")]
        [Range(100, 3000, ErrorMessage = "Cost per hour should be in range from 100 to 3000")]
        public int CostPerHour { get; set; }

        public OrderViewModel CurrentOrder { get; set; }

        public int? CurrentOrderId { get; set; }

        [JsonIgnore]
        public PointOfRentalViewModel PointOfRental { get; set; }

        [Required(ErrorMessage = "Enter point of rental id")]
        [MinLength(1, ErrorMessage = "Point of rental id should be more than 0")]
        public int PointOfRentalId { get; set; }
    }
}