using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CarRentalSystem.Domain.Entities.Base;
using CarRentalSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Infrastructure.Data
{
    public class CarRentalSystemGenericRepository<TEntity>: IRentalRepository<TEntity> where TEntity: BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public CarRentalSystemGenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task Create(TEntity item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> FindById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task Remove(TEntity item)
        {
            await Task.Run(() => _dbSet.Remove(item));
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity item)
        {
            await Task.Run(() => _context.Entry(item).State = EntityState.Modified);
            await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<TEntity>> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = await Task.Run(() => _dbSet.AsNoTracking());

            return await Task.Run(() => includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty)));
        }
    }
}
