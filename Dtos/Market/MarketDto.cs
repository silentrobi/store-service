using System;
using AutoMapper;

namespace StoreService.Dtos.Market
{
      [AutoMap(typeof(Models.Market), ReverseMap = true)]
    public class MarketDto
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
    }
}