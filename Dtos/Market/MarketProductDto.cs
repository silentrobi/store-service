using System;
using System.Collections.Generic;
using AutoMapper;
using StoreService.Dtos.Product;

namespace StoreService.Dtos.Market
{
    [AutoMap(typeof(Models.Market), ReverseMap = true)]
    public class MarketProductDto
    {
        public Guid Id { get; set; }

        public IList<ProductDto> Products { get; set; }
    }
}