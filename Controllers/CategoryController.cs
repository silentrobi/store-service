using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreService.Dtos.Category;
using StoreService.Services.Category;

namespace StoreService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;
        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAysnc()
        {
            return Ok(await _categoryService.GetAync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(Guid id)
        {
            return Ok(await _categoryService.GetOneAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryDto createCategoryDto)
        {
            return Ok(await _categoryService.CreateAsync(createCategoryDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            return Ok(await _categoryService.UpdateAsync(id, updateCategoryDto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok();
        }
    }
}
