using System;

namespace eCommerce.Application.Dto
{
    public class ProductOptionDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsNew { get; set; }
    }
}