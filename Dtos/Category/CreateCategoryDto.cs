using AutoMapper;

namespace StoreService.Dtos.Category
{
    [AutoMap(typeof(Models.Category), ReverseMap = true)]
    public class CreateCategoryDto
    {
        public string Name { get; set; }
    }
}