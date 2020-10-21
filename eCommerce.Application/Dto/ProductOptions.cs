using System.Collections.Generic;
using System.Linq;

namespace eCommerce.Application.Dto
{
    public class ProductOptions
    {
        public IEnumerable<ProductOptionDto> Items { get; set; }
        public int TotalProducts => Items.Count();

        public ProductOptions()
        {
            Items = new List<ProductOptionDto>();
        }
    }
}