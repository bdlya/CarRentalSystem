﻿using System;
using CarRentalSystem.Domain.Entities.Base;

namespace CarRentalSystem.Domain.Entities
{
    public class RefreshToken: BaseEntity
    {
        public int? UserId { get; set; }

        public User User { get; set; }

        public string Token { get; set; }
        
        public DateTime Expires { get; set; }

        public bool IsExpired => DateTime.Now >= Expires;

        public DateTime Created { get; set; }

        public DateTime? Revoked { get; set; }

        public bool IsActive => Revoked == null && !IsExpired;
    }
}