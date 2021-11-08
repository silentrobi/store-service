using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreService.Models
{
    public class Category : Common
    {
        [Key]
        public Guid Id { get; set; }
        public string name { get; set; }

        public IList<Product> Products { get; set; }
    }
}