using System;
using CarRentalSystem.View.ViewModels.Base;

namespace CarRentalSystem.View.ViewModels
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