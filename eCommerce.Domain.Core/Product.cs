using eCommerce.Domain.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eCommerce.Domain.Core
{
    public class Product : AggregateRoot<Guid>
    {
        private List<ProductOption> _productOptions;
        public IEnumerable<ProductOption> ProductOptions => _productOptions.AsReadOnly();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public decimal DeliveryPrice { get; private set; }
        public bool IsNew { get; private set; }

        protected Product()
        {
            Id = Guid.NewGuid();
            IsNew = true;
            _productOptions = new List<ProductOption>();
        }

        private Product(string name,
            string description,
            decimal price,
            decimal deliveryPrice) : this()
        {
            Name = name;
            Description = description;
            Price = price;
            DeliveryPrice = deliveryPrice;
        }

        public static Product Create(string name,
            string description,
            decimal price,
            decimal deliveryPrice)
        {
            Validate(name,
                description,
                price,
                deliveryPrice);

            var product = new Product(name,
                description,
                price,
                deliveryPrice);

            return product;
        }

        public void Update(string name, 
            string description, 
            decimal price, 
            decimal deliveryPrice)
        {
            Product.Validate(name,
                description,
                price,
                deliveryPrice);

            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.DeliveryPrice = deliveryPrice;
        }

        public void UpdateProductOption(Guid productOptionId,
            string name,
            string description)
        {
            if (!_productOptions.Any(item => item.Id == productOptionId))
                throw new ArgumentNullException($"Could not locate Product-Option '{productOptionId}' with Product Id '{this.Id}'");

            var productOption = _productOptions.First(item => item.Id == productOptionId);
            productOption.Update(name, description);
        }

        public ProductOption GetProductOption(Guid productOptionId)
        {
            if (!_productOptions.Any(item => item.Id == productOptionId)) return null;

            var productOption = _productOptions.First(item => item.Id == productOptionId);
            return productOption;
        }

        public void DeleteProductOption(Guid productOptionId)
        {
            if (!_productOptions.Any(item => item.Id == productOptionId))
                throw new ArgumentNullException($"Could not locate Product-Option '{productOptionId}' with Product Id '{this.Id}'");

            var productOption = _productOptions.First(item => item.Id == productOptionId);
            productOption.Delete();
        }

        private static void Validate(string name,
            string description,
            decimal price,
            decimal deliveryPrice)
        {
            Check.IsNullOrWhiteSpace(nameof(name), name);
            Check.IsNullOrWhiteSpace(nameof(description), description);
            if (price <= 0 || price > 10000)
                throw new ArgumentOutOfRangeException($"Specified value '{price}' for '{nameof(price)}' is Invalid. Please provide valid range between 0 and 10,000.");
            if (deliveryPrice < 0 || deliveryPrice > 10000)
                throw new ArgumentOutOfRangeException($"Specified value '{deliveryPrice}' for '{nameof(deliveryPrice)}' is Invalid. Please provide valid range between 0 and 10,000.");
        }

        public void AddProductOption(ProductOption productOption)
        {
            if (productOption == null)
                throw new ArgumentNullException($"Cannot add empty product option to product with id '{this.Id}'");

            if (IsDuplicateProductOption(productOption))
                throw new ArgumentNullException($"Cannot add duplicate product option ({productOption.Name}, {productOption.Description}) to product with id '{this.Id}'.");

            _productOptions.Add(productOption);
        }

        private bool IsDuplicateProductOption(ProductOption productOption)
        {
            return _productOptions.Any(item => item.Name == productOption.Name &&
                item.Description == productOption.Description);
        }
    }
}