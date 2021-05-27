using System;
using System.Collections.Generic;
using System.Linq;
using CarRentalSystem.Domain.Entities.Main;
using CarRentalSystem.Persistence.Data.Helpers.Interfaces;

namespace CarRentalSystem.Persistence.Data.Helpers.Implementations
{
    public class OrdersCreator : IEntitiesCreator<Order>
    {
        public IEnumerable<Order> CreateEntities()
        {
            int ordersCount = 30;
            int orderId = 1;

            Random rnd = new Random();

            return Enumerable.Repeat(new Order(), ordersCount).Select(order => new Order()
            {
                Id = orderId++,
                StartDate = new DateTime().AddDays(rnd.Next(11)),
                EndDate = new DateTime().AddDays(rnd.Next(11, 21)),
                TotalCost = rnd.Next(300, 3001),
                CurrentCustomerId = rnd.Next(1, 16),
                CarId = rnd.Next(1, 31),
            });
        }
    }
}