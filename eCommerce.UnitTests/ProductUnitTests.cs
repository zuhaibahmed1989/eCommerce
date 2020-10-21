using eCommerce.Domain.Core;
using System;
using System.Linq;
using Xunit;

namespace eCommerce.UnitTests
{
    public class ProductUnitTests
    {
        [Fact]
        public void TestProductCreation()
        {
            string name = "Apple iPhone 12 Pro Max";
            string description = "The iPhone 12 Pro is 5G capable, has a 6.1 inch Super Retina XDR display, and new possibilities with improved night mode camera lenses";
            decimal price = 1500.00m;
            decimal deliveryPrice = 0.00m;

            var product = Product.Create(name,
                description,
                price,
                deliveryPrice);

            Assert.Equal(name, product.Name);
            Assert.Equal(description, product.Description);
            Assert.Equal(price, product.Price);
            Assert.Equal(deliveryPrice, product.DeliveryPrice);
            Assert.True(product.IsNew);
        }

        [Fact]
        public void TestProductOptionCreation()
        {
            Guid productId = Guid.NewGuid();
            string name = "Storage Capacity";
            string description = "64 GB";

            var productOption = ProductOption.Create(productId,
                name,
                description);

            Assert.Equal(name, productOption.Name);
            Assert.Equal(description, productOption.Description);
            Assert.True(productOption.IsNew);
        }

        [Fact]
        public void TestAddingOptionsToProduct()
        {
            var product = Product.Create(name: "Apple iPhone 12 Pro Max",
                description: "The iPhone 12 Pro is 5G capable, has a 6.1 inch Super Retina XDR display, and new possibilities with improved night mode camera lenses",
                price: 1650.00m,
                deliveryPrice: 10.00m);

            var storageCapacity64GB = ProductOption.Create(product.Id,
                name: "Storage Capacity",
                description: "64 GB");

            var storageCapacity128GB = ProductOption.Create(product.Id,
                name: "Storage Capacity",
                description: "128 GB");

            product.AddProductOption(storageCapacity64GB);
            product.AddProductOption(storageCapacity128GB);

            Assert.NotNull(product.ProductOptions);
            Assert.True(product.ProductOptions.Count() == 2);
            Assert.All(product.ProductOptions, x => IsNewProductOption(x));
            Assert.Contains(product.ProductOptions, item => item
                .Name
                .Equals(storageCapacity64GB.Name, StringComparison.InvariantCultureIgnoreCase));
            Assert.Contains(product.ProductOptions, item => item
                .Name
                .Equals(storageCapacity128GB.Name, StringComparison.InvariantCultureIgnoreCase));
        }

        private bool IsNewProductOption(ProductOption productOption)
        {
            return productOption.IsNew;
        }
    }
}