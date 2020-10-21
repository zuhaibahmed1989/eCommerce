using System;

namespace eCommerce.Core
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public decimal DeliveryPrice { get; private set; }
        public bool IsNew { get; private set; }

        protected Product()
        {
            Id = Guid.NewGuid();
            IsNew = true;
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
            var product = new Product(name,
                description,
                price,
                deliveryPrice);

            return product;
        }
    }
}