using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StoreService.Database.Contexts;

namespace StoreService.Repositories.Category
{
    public class CategoryRepository : CrudRepository<Models.Category, Guid>, ICategoryRepository
    {
        private readonly StoreDbContext _dbContext;
        public CategoryRepository(StoreDbContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}