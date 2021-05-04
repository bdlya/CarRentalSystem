using System.Collections.Generic;
using CarRentalSystem.Domain.Entities.Base;
using CarRentalSystem.Domain.Entities.Support;

namespace CarRentalSystem.Domain.Entities.Main
{
    public class User: BaseEntity
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public string Login { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Role { get; set; }

        public string Token { get; set; }

        public int? RefreshTokenId { get; set; }

        public RefreshToken RefreshToken { get; set; }

        public List<Order> Orders { get; set; }

        public User()
        {
            Orders = new List<Order>();
        }
    }
}