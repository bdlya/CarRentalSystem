using System;
using System.Collections.Generic;
using System.Linq;
using CarRentalSystem.Domain.Entities.Main;
using CarRentalSystem.Persistence.Data.Helpers.Interfaces;

namespace CarRentalSystem.Persistence.Data.Helpers.Implementations
{
    public class UsersCreator : IEntitiesCreator<User>
    {
        public IEnumerable<User> CreateEntities()
        {
            string[][] propertiesData =
            {
                new[] { "John", "Mark", "Arthur", "Angela", "Sonya", "Emily"},
                new[] { "Morgan", "Johnson", "Smith", "Green", "Down", "Lee"},
            };

            int usersCount = 15;
            int userId = 1;

            int maxRange = 6;
            Random rnd = new Random();

            return Enumerable.Repeat(new User(), usersCount).Select(user => new User
            {
                Id = userId++,
                Name = propertiesData[0][rnd.Next(maxRange)],
                SurName = propertiesData[1][rnd.Next(maxRange)],
                Login = $"Login {userId - 1}",
            });
        }
    }
}