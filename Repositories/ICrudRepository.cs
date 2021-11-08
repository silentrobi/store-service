using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StoreService.Repositories
{
    public interface ICrudRepository<T, Tkey> where T : class
    {
        IEnumerable<T> Find();
        T FindById(Tkey id);
        T Insert(T entity);
        T Delete(Tkey id);
        T Upsert(T entity);
        T Update(T entity);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}