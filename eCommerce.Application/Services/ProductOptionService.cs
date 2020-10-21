using eCommerce.Application.Dto;
using eCommerce.Domain.Core;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Application.Services
{
    public class ProductOptionService : IProductOptionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public ProductOptionService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            _productRepository = unitOfWork.ProductRepository;
        }

        public async Task AddAsync(ProductOptionDto productOptionDto)
        {
            var productOption = ProductOption.Create(productOptionDto.ProductId,
                productOptionDto.Name,
                productOptionDto.Description);

            var product = await _productRepository.GetAsync(productOptionDto.ProductId);
            product.AddProductOption(productOption);
            await this._unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Guid productId,
            Guid productOptionId,
            ProductOptionDto productOption)
        {
            var product = await _productRepository.GetAsync(productId);

            product.UpdateProductOption(productOptionId,
                productOption.Name,
                productOption.Description);

            await this._unitOfWork.CommitAsync();
        }

        public async Task<ProductOptions> GetAllAsync(Guid productId)
        {
            var product = await _productRepository.GetAsync(productId);

            return new ProductOptions()
            {
                Items = product
                .ProductOptions
                .Select(productOption => ProductMapper.GetProductOptionDto(productOption))
                .ToList()
            };
        }

        public async Task<ProductOptionDto> GetProductOptionAsync(Guid productId, Guid productOptionId)
        {
            var product = await _productRepository.GetAsync(productId);
            var productOption = product.GetProductOption(productOptionId);
            return ProductMapper.GetProductOptionDto(productOption);
        }

        public async Task DeleteAsync(Guid productId, Guid productOptionId)
        {
            var product = await _productRepository.GetAsync(productId);

            product.DeleteProductOption(productOptionId);

            await this._unitOfWork.CommitAsync();
        }
    }
}