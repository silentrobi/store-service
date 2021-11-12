using System;
using System.Threading.Tasks;
using StoreService.Dtos.Category;

namespace StoreService.Repositories.Category
{
    public interface ICategoryRepository : ICrudRepository<Models.Category, Guid>
    {
        Task<CategoryDetailDto> GetCategoryDetailAsync(Guid id);
    }
}