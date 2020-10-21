using eCommerce.Application.Dto;
using eCommerce.Domain.Core;
using System.Collections.Generic;

namespace eCommerce.Application
{
    public class ProductMapper
    {
        public static ProductDto GetProductDto(Product product)
        {
            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                IsNew = product.IsNew,
                Price = product.Price,
                DeliveryPrice = product.DeliveryPrice,
                ProductOptions = new List<ProductOptionDto>()
            };
        }

        public static ProductOptionDto GetProductOptionDto(ProductOption productOption)
        {
            return new ProductOptionDto()
            {
                Id = productOption.Id,
                Name = productOption.Name,
                Description = productOption.Description,
                ProductId = productOption.ProductId,
                IsNew = productOption.IsNew
            };
        }
    }
}