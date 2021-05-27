using System;
using System.Collections.Generic;
using System.Linq;
using CarRentalSystem.Domain.Entities.Main;
using CarRentalSystem.Persistence.Data.Helpers.Interfaces;

namespace CarRentalSystem.Persistence.Data.Helpers.Implementations
{
    public class PointOfRentalsCreator : IEntitiesCreator<PointOfRental>
    {
        public IEnumerable<PointOfRental> CreateEntities()
        {
            string[][] propertiesData =
            {
                new[] { "Home", "Galaxy", "Destiny", "Hello", "Axe"},
                new[] { "Belarus", "USA", "Canada", "Japan", "Brazil"},
                new[] { "Minsk", "New York", "Montreal", "Japan", "Brasilia"}
            };

            int pointsCount = 10;
            int pointId = 1;

            Random rnd = new Random();
            int maxRange = propertiesData[0].Length;

            return Enumerable.Repeat(new PointOfRental(), pointsCount).Select(point => new PointOfRental()
            {
                Id = pointId++,
                Name = propertiesData[0][rnd.Next(maxRange)],
                Country = propertiesData[1][rnd.Next(maxRange)],
                City = propertiesData[2][rnd.Next(maxRange)],
                Address = $"Street {rnd.Next(maxRange)}"
            });
        }
    }
}