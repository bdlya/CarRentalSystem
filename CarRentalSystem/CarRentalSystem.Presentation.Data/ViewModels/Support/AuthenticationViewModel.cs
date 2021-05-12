using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Presentation.Data.ViewModels.Support
{
    public class AuthenticationViewModel
    {
        [Required(ErrorMessage = "Login is required")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}