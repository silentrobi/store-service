using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StoreService.Repositories
{
    public interface ICrudRepository<T, Tkey> where T : class
    {
        ICollection<T> Find();
        T FindById(Tkey id);
        T Insert(T entity);
        void Delete(T entity);
        T Upsert(T entity);
        T Update(T entity);
        ICollection<T> Find(Expression<Func<T, bool>> predicate);
    }
}