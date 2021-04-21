using System.Collections.Generic;
using CarRentalSystem.View.ViewModels.Base;

namespace CarRentalSystem.View.ViewModels
{
    public class UserViewModel: BaseEntityViewModel
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public string Login { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Role { get; set; }

        public string Token { get; set; }

        public List<OrderViewModel> Orders { get; set; }

        public UserViewModel()
        {
            Orders = new List<OrderViewModel>();
        }
    }
}