using eCommerce.Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.DataAccess
{
    class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            this._context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task<Product> GetAsync(Guid id)
        {
            return await _context
                .Products
                .Include(p => p.ProductOptions)
                .FirstAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context
                .Products
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product> SearchAsync(string productName)
        {
            return await _context
                .Products
                .Include(p => p.ProductOptions)
                .FirstAsync(p => p.Name.ToLower() == productName.ToLower());
        }
    }
}