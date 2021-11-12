using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreService.Dtos.Category;

namespace StoreService.Services.Category
{
    public interface ICategoryService
    {
        Task<IList<Models.Category>> GetAync();

        Task<CategoryDto> GetOneAsync(Guid id);
        Task<CategoryDto> CreateAsync(CreateCategoryDto categoryDto);

        Task<CategoryDto> UpdateAsync(Guid id, UpdateCategoryDto categoryDto);

        Task DeleteAsync(Guid id);
    }
}
