using System.Linq;
using System.Threading.Tasks;

namespace CarRentalSystem.Domain.Interfaces.Repository
{
    public interface ICarRentalSystemRepository<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity item);

        Task<TEntity> FindByIdAsync(int id);

        Task RemoveAsync(TEntity item);

        Task UpdateAsync(TEntity item);

        Task<IQueryable<TEntity>> GetAsQueryable();
    }
}
