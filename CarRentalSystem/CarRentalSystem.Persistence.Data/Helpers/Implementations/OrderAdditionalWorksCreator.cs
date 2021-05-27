using System;
using System.Collections.Generic;
using System.Linq;
using CarRentalSystem.Domain.Entities.Support;
using CarRentalSystem.Persistence.Data.Helpers.Interfaces;

namespace CarRentalSystem.Persistence.Data.Helpers.Implementations
{
    public class OrderAdditionalWorksCreator : IEntitiesCreator<OrderAdditionalWork>
    {
        public IEnumerable<OrderAdditionalWork> CreateEntities()
        {
            int orderAdditionalWorksCount = 30;
            int orderId = 1;
            int additionalWorkId = 1;

            Random rnd = new Random();

            return Enumerable.Repeat(new OrderAdditionalWork(), orderAdditionalWorksCount).Select(orderAdditionalWork => new OrderAdditionalWork
            {
                OrderId = orderId++,
                AdditionalServiceId = CorrectAdditionalWorkId(additionalWorkId)
            });
        }

        private int CorrectAdditionalWorkId(int additionalWorkId)
        {
            return additionalWorkId == 11 ? 1 : ++additionalWorkId;
        }
    }
}