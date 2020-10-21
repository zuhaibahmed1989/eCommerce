using eCommerce.Domain.Core.Common;
using System;

namespace eCommerce.Domain.Core
{
    public class ProductOption : Entity<Guid>
    {
        public Guid ProductId { get; private set; }
        public Product Product { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsNew { get; private set; }

        protected ProductOption()
        {
            Id = Guid.NewGuid();
            IsNew = true;
        }

        private ProductOption(Guid productId,
            string name,
            string description) : this()
        {
            ProductId = productId;
            Name = name;
            Description = description;
        }

        public static ProductOption Create(Guid productId,
            string name,
            string description)
        {
            Validate(productId,
                name,
                description);

            return new ProductOption(productId,
                name,
                description);
        }

        private static void Validate(Guid productId,
            string name,
            string description)
        {
            Check.IsNullOrEmpty(nameof(productId), productId);
            Check.IsNullOrWhiteSpace(nameof(name), name);
            Check.IsNullOrWhiteSpace(nameof(description), description);
        }

        internal void Update(string name, string description)
        {
            Check.IsNullOrWhiteSpace(nameof(name), name);
            Check.IsNullOrWhiteSpace(nameof(description), description);

            this.Name = name;
            this.Description = description;
        }
    }
}