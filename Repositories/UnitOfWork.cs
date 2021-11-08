using System.Threading.Tasks;
using StoreService.Database.Contexts;

namespace StoreService.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;

        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
        }

        public async virtual Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }
}
