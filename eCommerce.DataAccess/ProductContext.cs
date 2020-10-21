using eCommerce.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.DataAccess
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(Product => Product.ProductOptions)
                .WithOne(productOption => productOption.Product)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasQueryFilter(x => !x.IsDeleted);

            modelBuilder.Entity<ProductOption>()
                .HasQueryFilter(x => !x.IsDeleted);

            modelBuilder.Entity<Product>().Ignore(x => x.IntegrationEvents);
            modelBuilder.Entity<Product>().Ignore(x => x.DomainEvents);
        }

        public DbSet<Product> Products { get; set; }
    }
}