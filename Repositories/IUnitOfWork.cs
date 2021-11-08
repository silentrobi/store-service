using System;
using System.Threading.Tasks;

namespace StoreService.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CompleteAsync();
    }
}
