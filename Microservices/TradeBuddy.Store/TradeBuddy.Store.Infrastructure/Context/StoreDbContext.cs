using Microsoft.EntityFrameworkCore;
using TradeBuddy.Store.Domain.Entities;
using TradeBuddy.Store.Domain.ValueObjects;

namespace TradeBuddy.Store.Infrastructure.Context
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // تنظیمات Brand
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Id)
                      .HasConversion(id => id.Value, value => new BrandId(value));

                entity.Property(b => b.Name)
                      .HasConversion(name => name.Value, value => new BrandName(value))
                      .IsRequired()
                      .HasMaxLength(100);
            });

            // تنظیمات Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id)
                      .HasConversion(id => id.Value, value => new CategoryId(value));

                entity.Property(c => c.Name)
                      .HasConversion(name => name.Value, value => new CategoryName(value))
                      .IsRequired()
                      .HasMaxLength(100);

                // رابطه با Products (در صورت وجود رابطه)
                entity.HasMany(c => c.Products)
                      .WithOne(p => p.Category)
                      .HasForeignKey(p => p.CategoryId);
            });

            // تنظیمات Product
            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .HasConversion(id => id.Value, value => new ProductId(value));

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasConversion(name => name.Value, value => new ProductName(value))
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasConversion(price => price.Value, value => new Price(value))
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.CategoryId)
                .HasConversion(id => id.Value, value => new CategoryId(value))
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.BrandId)
                .HasConversion(id => id.Value, value => new BrandId(value))
                .IsRequired();
        }
    }
}
