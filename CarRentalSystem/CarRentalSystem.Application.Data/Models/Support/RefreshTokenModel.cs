using System;
using CarRentalSystem.Application.Data.Models.Base;
using CarRentalSystem.Application.Data.Models.Main;

namespace CarRentalSystem.Application.Data.Models.Support
{
    public class RefreshTokenModel: BaseEntityModel
    {
        public int? UserId { get; set; }

        public UserModel User { get; set; }

        public string Token { get; set; }
        
        public DateTime Expires { get; set; }

        public bool IsExpired => DateTime.Now >= Expires;

        public DateTime Created { get; set; }

        public DateTime? Revoked { get; set; }

        public bool IsActive => Revoked == null && !IsExpired;
    }
}