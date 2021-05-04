using CarRentalSystem.Presentation.Data.ViewModels.Base;
using CarRentalSystem.Presentation.Data.ViewModels.Main;
using System;

namespace CarRentalSystem.Presentation.Data.ViewModels.Support
{
    public class RefreshTokenViewModel: BaseEntityViewModel
    {
        public string UserId { get; set; }

        public UserViewModel User { get; set; }

        public string Token { get; set; }
        
        public DateTime Expires { get; set; }

        public bool IsExpired => DateTime.Now >= Expires;

        public DateTime Created { get; set; }

        public DateTime? Revoked { get; set; }

        public bool IsActive => Revoked == null && !IsExpired;
    }
}