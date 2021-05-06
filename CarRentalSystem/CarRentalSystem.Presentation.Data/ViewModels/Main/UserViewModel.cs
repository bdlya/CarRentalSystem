using CarRentalSystem.Presentation.Data.ViewModels.Base;
using CarRentalSystem.Presentation.Data.ViewModels.Support;
using System.Collections.Generic;

namespace CarRentalSystem.Presentation.Data.ViewModels.Main
{
    public class UserViewModel: BaseEntityViewModel
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public string Login { get; set; }

        public string Role { get; set; }

        public string Token { get; set; }

        public RefreshTokenViewModel RefreshToken { get; set; }

        public List<OrderViewModel> Orders { get; set; }

        public UserViewModel()
        {
            Orders = new List<OrderViewModel>();
        }
    }
}