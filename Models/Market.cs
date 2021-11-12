using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreService.Models
{
    public class Market : Common
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public IList<MarketProduct> MarketProducts { get; set; }
    }
}