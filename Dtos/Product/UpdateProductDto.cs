using AutoMapper;

namespace StoreService.Dtos.Product
{
    [AutoMap(typeof(Models.Product), ReverseMap = true)]
    public class UpdateProductDto
    {
        public string Name { get; set; }
        public int StockCount { get; set; }
    }
}