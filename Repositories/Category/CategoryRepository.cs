using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StoreService.Database.Contexts;
using StoreService.Dtos.Category;
using StoreService.Dtos.Product;

namespace StoreService.Repositories.Category
{
    public class CategoryRepository : CrudRepository<Models.Category, Guid>, ICategoryRepository
    {
        private readonly StoreDbContext _dbContext;
        public CategoryRepository(StoreDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<CategoryDetailDto> GetCategoryDetailAsync(Guid id)
        {
            return await _dbContext.Categories.AsNoTracking().Include(x => x.Products)
            .ThenInclude(x => x.ProductMarkets).Select(x =>
               new CategoryDetailDto()
               {
                   Id = x.Id,
                   Name = x.Name,
                   Products = x.Products.Select(x => new ProductDto()
                   {
                       Id = x.Id,
                       Name = x.Name,
                       CategoryId = x.Category.Id,
                       StockCount = x.StockCount,
                       MarketIds = x.ProductMarkets.Select(x => x.MarketId).ToList()
                   }).ToList()
               }).FirstOrDefaultAsync();
        }
    }
}