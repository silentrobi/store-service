using AutoMapper;

namespace StoreService.Dtos.Market
{
    [AutoMap(typeof(Models.Market), ReverseMap = true)]
    public class UpdateMarketDto
    {
        public string name { get; set; }
        public string address { get; set; }
    }
}