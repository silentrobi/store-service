using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StoreService.Repositories
{
    public abstract class CrudRepository<T, TKey> : ICrudRepository<T, TKey> where T : class
    {
        protected DbContext _context;

        public CrudRepository(DbContext context)
        {
            _context = context;
        }

        public virtual ICollection<T> Find()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T GetById(TKey id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual T Add(T entity)
        {
            return _context.Set<T>().Add(entity).Entity;

        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual T Upsert(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual ICollection<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public T FindById(TKey id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Insert(T entity)
        {
            return _context.Set<T>().Add(entity).Entity;
        }

        public T Update(T entity)
        {
            return _context.Set<T>().Update(entity).Entity;
        }
    }
}