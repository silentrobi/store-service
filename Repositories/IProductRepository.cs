using System;
using StoreService.Models;

namespace StoreService.Repositories
{
    public interface IProductRepository : ICrudRepository<Product, Guid>
    {

    }
}