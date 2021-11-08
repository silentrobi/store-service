using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StoreService.Repositories
{
    public class CrudRepository<T, TKey> : ICrudRepository<T, TKey> where T : class
    {
        protected DbContext _context;

        protected readonly ILogger _logger;

        public CrudRepository(DbContext context, ILogger logger)
        {
            _context = context;
            this._logger = logger;
        }

        public virtual IEnumerable<T> Find()
        {
            throw new NotImplementedException();
        }

        public virtual T GetById(TKey id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual T Add(T entity)
        {
            return _context.Set<T>().Add(entity).Entity;

        }

        public virtual T Delete(TKey id)
        {
            throw new NotImplementedException();
        }

        public virtual T Upsert(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public T FindById(TKey id)
        {
            throw new NotImplementedException();
        }

        public T Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}