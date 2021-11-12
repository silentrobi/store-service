using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StoreService.Dtos.Category;
using StoreService.Dtos.Product;
using StoreService.Repositories;
using StoreService.Repositories.Category;

namespace StoreService.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private static readonly string[] Summaries = new[]
       {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryRepository categoryRepository,
                IMapper mapper,
                IUnitOfWork unitOfWork
                )
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        public async Task<CategoryDto> CreateAsync(CreateCategoryDto categoryDto)
        {
            Models.Category categoryEntity = _mapper.Map<Models.Category>(categoryDto);
            var result = _categoryRepository.Insert(categoryEntity);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<CategoryDto>(result);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = _categoryRepository.FindById(id);

            if (entity != null)
            {
                _categoryRepository.Delete(entity);
            }
            else
            {
                throw new Exception("Category Id not Found!");
            }

            await _unitOfWork.CompleteAsync();
        }

        public async Task<IList<Models.Category>> GetAync()
        {
            return _categoryRepository.Find().ToList();
        }

        public async Task<CategoryDetailDto> GetCategoryDetailAsync(Guid id)
        {
            var categoryEntity = await _categoryRepository.GetCategoryDetailAsync(id);
            CategoryDetailDto categoryDetailDto = new CategoryDetailDto()
            {
                Id = categoryEntity.Id,
                name = categoryEntity.name,
                Products = _mapper.Map<IList<ProductDto>>(categoryEntity.Products.Select(x => new ProductDto()
                {
                    Id = x.Id,
                    name = x.name,
                    CategoryId = x.Category.Id,
                    stockCount = x.stockCount,
                    MarketIds = x.ProductMarkets.Select(x => x.MarketId).ToList()
                }).ToList())
            };

            return categoryDetailDto;
        }

        public async Task<CategoryDto> GetOneAsync(Guid id)
        {
            return _mapper.Map<CategoryDto>(_categoryRepository.FindById(id));
        }

        public async Task<CategoryDto> UpdateAsync(Guid id, UpdateCategoryDto categoryDto)
        {
            Models.Category categoryEntity = _categoryRepository.FindById(id);

            if (categoryEntity == null) throw new Exception("Category Id not Found!");

            categoryEntity.name = categoryDto.name;

            _categoryRepository.Update(categoryEntity);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<CategoryDto>(categoryEntity);
        }
    }
}