using System;
using System.Collections.Generic;
using AutoMapper;

namespace StoreService.Dtos.Product
{
    [AutoMap(typeof(Models.Product), ReverseMap = true)]
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public int stockCount { get; set; }

        public Guid CategoryId { get; set; }
        public IList<Guid> MarketIds { get; set; }
    }
}