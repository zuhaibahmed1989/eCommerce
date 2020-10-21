using System.Collections.Generic;
using System.Linq;

namespace eCommerce.Application.Dto
{
    public class Products
    {
        public IEnumerable<ProductDto> Items { get; set; }
        public int TotalProducts => Items.Count();

        public Products()
        {
            Items = new List<ProductDto>();
        }
    }
}