using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRentalSystem.Domain.Interfaces
{
    public interface IRentalRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity item);
        Task<TEntity> FindById(int id);
        Task<IEnumerable<TEntity>> Get();
        Task Remove(TEntity item);
        Task Update(TEntity item);
        Task<IQueryable<TEntity>> Include(params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
