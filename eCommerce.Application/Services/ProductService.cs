using eCommerce.Application.Dto;
using eCommerce.Domain.Core;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            _productRepository = unitOfWork.ProductRepository;
        }

        public async Task AddAsync(ProductDto productDto)
        {
            var product = Product.Create(productDto.Name,
                productDto.Description,
                productDto.Price,
                productDto.DeliveryPrice);

            await _productRepository.AddAsync(product);
            await this._unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Guid productId,
            ProductDto productDto)
        {
            var product = await _productRepository.GetAsync(productId);

            product.Update(productDto.Name,
                productDto.Description,
                productDto.Price,
                productDto.DeliveryPrice);

            await this._unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid productId)
        {
            var product = await _productRepository.GetAsync(productId);
            product.Delete();
            await this._unitOfWork.CommitAsync();
        }

        public async Task<Products> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();

            return new Products()
            {
                Items = products
                .Select(product => ProductMapper.GetProductDto(product))
                .ToList()
            };
        }

        public async Task<ProductDto> GetAsync(Guid productId)
        {
            var product = await _productRepository.GetAsync(productId);
            var productDto = ProductMapper.GetProductDto(product);

            productDto.ProductOptions = product
                .ProductOptions
                .Select(productOption => ProductMapper.GetProductOptionDto(productOption))
                .ToList();

            return productDto;
        }

        public async Task<ProductDto> SearchProductAsync(string productName)
        {
            var product = await _productRepository.SearchAsync(productName);
            var productDto = ProductMapper.GetProductDto(product);

            return productDto;
        }
    }
}