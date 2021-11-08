using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreService.Models
{
    public class Product : Common
    {
        [Key]
        public Guid Id { get; set; }
        public string name { get; set; }
        public int stockCount { get; set; }

        public IList<MarketProduct> ProductMarkets { get; set; }

        public Category Category { get; set; }
    }
}