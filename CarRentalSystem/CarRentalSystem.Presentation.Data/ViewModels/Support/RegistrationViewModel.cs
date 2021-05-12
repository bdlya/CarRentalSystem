using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Presentation.Data.ViewModels.Support
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Name should be at least three symbols long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [MinLength(3, ErrorMessage = "Surname should be at least three symbols long")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Login is required")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}