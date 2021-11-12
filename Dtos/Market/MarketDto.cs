using System;
using AutoMapper;

namespace StoreService.Dtos.Market
{
      [AutoMap(typeof(Models.Market), ReverseMap = true)]
    public class MarketDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}