using System;

namespace StoreService.Repositories.Product
{
    public interface IProductRepository : ICrudRepository<Models.Product, Guid>
    {

    }
}