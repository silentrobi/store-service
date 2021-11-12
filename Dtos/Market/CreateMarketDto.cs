using AutoMapper;

namespace StoreService.Dtos.Market
{
    [AutoMap(typeof(Models.Market), ReverseMap = true)]
    public class CreateMarketDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}