using System.Collections.Generic;
using CarRentalSystem.Application.Data.Models.Base;
using CarRentalSystem.Application.Data.Models.Support;

namespace CarRentalSystem.Application.Data.Models.Main
{
    public class UserModel: BaseEntityModel
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public string Login { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Role { get; set; }

        public string Token { get; set; }

        public int? RefreshTokenId { get; set; }

        public RefreshTokenModel RefreshToken { get; set; }

        public List<OrderModel> Orders { get; set; }

        public UserModel()
        {
            Orders = new List<OrderModel>();
        }
    }
}