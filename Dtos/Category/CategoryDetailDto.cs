using System;
using System.Collections.Generic;
using AutoMapper;
using StoreService.Dtos.Product;

namespace StoreService.Dtos.Category
{
    [AutoMap(typeof(Models.Category), ReverseMap = true)]
    public class CategoryDetailDto
    {
        public Guid Id { get; set; }
        public string name { get; set; }

        public IList<ProductDto> Products { get; set; }
    }
}