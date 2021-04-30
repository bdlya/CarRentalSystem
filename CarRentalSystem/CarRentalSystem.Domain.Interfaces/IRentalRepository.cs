using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRentalSystem.Domain.Interfaces
{
    public interface IRentalRepository<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity item);
        Task<TEntity> FindByIdAsync(int id);
        Task RemoveAsync(TEntity item);
        Task UpdateAsync(TEntity item);
        Task<IQueryable<TEntity>> GetAsQueryable();
    }
}
