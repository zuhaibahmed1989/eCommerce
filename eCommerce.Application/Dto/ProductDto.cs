using System;
using System.Collections.Generic;

namespace eCommerce.Application.Dto
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }
        public bool IsNew { get; set; }
        public IEnumerable<ProductOptionDto> ProductOptions { get; set; }

        public ProductDto()
        {
            ProductOptions = new List<ProductOptionDto>();
        }
    }
}