using AutoMapper;

namespace StoreService.Dtos.Product
{
    [AutoMap(typeof(Models.Product), ReverseMap = true)]
    public class CreateProductDto
    {

    }
}