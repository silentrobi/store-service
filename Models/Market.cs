using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreService.Models
{
    public class Market : Common
    {
        [Key]
        public Guid Id { get; set; }
        public string name { get; set; }
        public string address { get; set; }

        public IList<MarketProduct> MarketProducts { get; set; }
    }
}