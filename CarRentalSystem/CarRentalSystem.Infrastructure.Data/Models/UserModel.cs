﻿using System.Collections.Generic;
using CarRentalSystem.Infrastructure.Data.Models.Base;

namespace CarRentalSystem.Infrastructure.Data.Models
{
    public class UserModel: BaseEntityModel
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string Token { get; set; }

        public List<OrderModel> Orders { get; set; }

        public UserModel()
        {
            Orders = new List<OrderModel>();
        }
    }
}