using System.Collections.Generic;

namespace CarRentalSystem.Persistence.Data.Helpers.Interfaces
{
    public interface IEntitiesCreator<out TEntity>
    {
        IEnumerable<TEntity> CreateEntities();
    }
}