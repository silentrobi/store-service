using System;
using StoreService.Models;

namespace StoreService.Repositories
{
    public interface ICategoryRepository : ICrudRepository<Category, Guid>
    {

    }
}