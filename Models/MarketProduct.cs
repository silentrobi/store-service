using System;

namespace StoreService.Models
{
    public class MarketProduct
    {
        public Market Market { get; set; }
         public Guid MarketId { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
    }
}