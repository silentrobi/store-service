using AutoMapper;

namespace StoreService.Dtos.Category
{
      [AutoMap(typeof(Models.Category), ReverseMap = true)]
    public class UpdateCategoryDto
    {
        public string name { get; set; }
    }
}