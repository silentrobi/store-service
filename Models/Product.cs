using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreService.Models
{
    public class Product : Common
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int StockCount { get; set; }

        public IList<MarketProduct> ProductMarkets { get; set; }

        public Category Category { get; set; }
    }
}