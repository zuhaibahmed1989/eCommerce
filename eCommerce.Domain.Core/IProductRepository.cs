using eCommerce.Domain.Core.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Domain.Core
{
    public interface IProductRepository : IRepository
    {
        Task AddAsync(Product product);
        Task<Product> GetAsync(Guid id);
        Task<Product> SearchAsync(string productName);
        Task<IEnumerable<Product>> GetAllAsync();
    }
}