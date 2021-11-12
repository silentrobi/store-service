using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StoreService.Database.Contexts;
using StoreService.Dtos.Category;

namespace StoreService.Repositories.Category
{
    public class CategoryRepository : CrudRepository<Models.Category, Guid>, ICategoryRepository
    {
        private readonly StoreDbContext _dbContext;
        public CategoryRepository(StoreDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<Models.Category> GetCategoryDetailAsync(Guid id)
        {
            return await _dbContext.Categories.AsNoTracking().Include(x => x.Products)
            .ThenInclude(x => x.ProductMarkets).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}