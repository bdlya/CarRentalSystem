﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CarRentalSystem.Domain.Interfaces
{
    public interface IRentalRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);
        TEntity FindById(int id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
        IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
