using System;
using System.Collections.Generic;
using System.Linq;
using CarRentalSystem.Domain.Entities.Main;
using CarRentalSystem.Persistence.Data.Helpers.Interfaces;

namespace CarRentalSystem.Persistence.Data.Helpers.Implementations
{
    public class AdditionalWorksCreator : IEntitiesCreator<AdditionalWork>
    {
        public IEnumerable<AdditionalWork> CreateEntities()
        {
            int additionalWorksCount = 10;
            int additionalWorkId = 1;

            return Enumerable.Repeat(new AdditionalWork(), additionalWorksCount).Select(additionalWork => new AdditionalWork
            {
                Id = additionalWorkId++,
                Name = $"Additional work {additionalWorkId - 1}",
                Cost = new Random().Next(100, 1001)
            });
        }
    }
}