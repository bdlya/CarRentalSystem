using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Presentation.Data.ViewModels.Support
{
    public class CarSearchViewModel
    {
        public string Brand { get; set; }

        public string TransmissionType { get; set; }

        public int NumberOfSeats { get; set; }
    }
}