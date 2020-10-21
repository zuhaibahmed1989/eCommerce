using eCommerce.Application.Dto;
using System;
using System.Threading.Tasks;

namespace eCommerce.Application.Services
{
    public interface IProductService : IApplicationService
    {
        Task AddAsync(ProductDto productDto);
        Task UpdateAsync(Guid id, ProductDto productDto);
        Task<Products> GetAllAsync();
        Task<ProductDto> GetAsync(Guid productId);
        Task<ProductDto> SearchProductAsync(string productName);
        Task DeleteAsync(Guid productId);
    }
}