using eCommerce.Application.Dto;
using System;
using System.Threading.Tasks;

namespace eCommerce.Application.Services
{
    public interface IProductOptionService : IApplicationService
    {
        Task AddAsync(ProductOptionDto productOptionDto);
        Task UpdateAsync(Guid productId,
            Guid productOptionId,
            ProductOptionDto productOption);
        Task<ProductOptions> GetAllAsync(Guid productId);
        Task<ProductOptionDto> GetProductOptionAsync(Guid productId, Guid productOptionId);
        Task DeleteAsync(Guid productId, Guid productOptionId);
    }
}