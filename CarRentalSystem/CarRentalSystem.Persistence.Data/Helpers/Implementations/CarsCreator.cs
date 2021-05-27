using System;
using System.Collections.Generic;
using System.Linq;
using CarRentalSystem.Domain.Entities.Main;
using CarRentalSystem.Persistence.Data.Helpers.Interfaces;

namespace CarRentalSystem.Persistence.Data.Helpers.Implementations
{
    public class CarsCreator : IEntitiesCreator<Car>
    {
        public IEnumerable<Car> CreateEntities()
        {
            string[][] propertiesData =
            {
                new[] { "BMW", "Nissan", "Mercedes", "Audi", "Toyota"},
                new[] { "Automatic", "Mechanic"},
            };

            int carsCount = 30;
            int carId = 1;

            Random rnd = new Random();

            return Enumerable.Repeat(new Car(), carsCount).Select(car => new Car()
            {
                Id = carId++,
                Brand = propertiesData[0][rnd.Next(5)],
                NumberOfSeats = rnd.Next(1, 9),
                AverageFuelConsumption = rnd.Next(100, 1001),
                TransmissionType = propertiesData[1][rnd.Next(2)],
                CostPerHour = rnd.Next(300, 3000),
                PointOfRentalId = rnd.Next(1, 11)
            });
        }
    }
}