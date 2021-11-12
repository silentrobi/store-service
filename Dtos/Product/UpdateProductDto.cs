using AutoMapper;

namespace StoreService.Dtos.Product
{
    [AutoMap(typeof(Models.Product), ReverseMap = true)]
    public class UpdateProductDto
    {
        public string name { get; set; }
        public int stockCount { get; set; }
    }
}