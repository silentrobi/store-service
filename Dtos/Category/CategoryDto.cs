using System;
using AutoMapper;

namespace StoreService.Dtos.Category
{
    [AutoMap(typeof(Models.Category), ReverseMap = true)]
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string name { get; set; }
    }
}