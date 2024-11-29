using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TradeBuddy.Store.Domain.Entities;
using TradeBuddy.Store.Domain.ValueObjects;

namespace TradeBuddy.Store.Infrastructure.Context
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FeatureDependency> FeatureDependencies { get; set; }
        public DbSet<FeatureValue> FeatureValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ValueConverters for ProductName, BrandName, CategoryName, and Price
            var productNameConverter = new ValueConverter<ProductName, string>(
                v => v.Value,
                v => new ProductName(v)
            );

            var brandNameConverter = new ValueConverter<BrandName, string>(
                v => v.Value,
                v => new BrandName(v)
            );

            var categoryNameConverter = new ValueConverter<CategoryName, string>(
                v => v.Value,
                v => new CategoryName(v)
            );

            var priceConverter = new ValueConverter<Price, decimal>(
                v => v.Value,
                v => new Price(v)
            );

            // Product entity
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name)
                    .HasConversion(productNameConverter)  // Apply converter for ProductName
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.Price)
                    .HasConversion(priceConverter)  // Apply converter for Price
                    .IsRequired();

                entity.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .IsRequired();

                entity.HasMany(p => p.ProductFeatures)
                    .WithOne(pf => pf.Product)
                    .HasForeignKey(pf => pf.ProductId)
                    .IsRequired();
            });

            // Category entity
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name)
                    .HasConversion(categoryNameConverter)  // Apply converter for CategoryName
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasMany(c => c.Products)
                    .WithOne(p => p.Category)
                    .HasForeignKey(p => p.CategoryId)
                    .IsRequired();
            });

            // Brand entity
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Name)
                    .HasConversion(brandNameConverter)  // Apply converter for BrandName
                    .IsRequired()
                    .HasMaxLength(100);
            });

            // ProductFeature entity
            modelBuilder.Entity<ProductFeature>(entity =>
            {
                entity.HasKey(pf => pf.Id);
                entity.HasOne(pf => pf.Product)
                    .WithMany(p => p.ProductFeatures)
                    .HasForeignKey(pf => pf.ProductId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction); // جلوگیری از Cascade Delete
            });

            // ProductVariant entity
            modelBuilder.Entity<ProductVariant>(entity =>
            {
                entity.HasKey(pv => pv.Id);
                entity.HasOne(pv => pv.Product)
                    .WithMany(p => p.ProductVariants)
                    .HasForeignKey(pv => pv.ProductId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction); // جلوگیری از Cascade Delete;
            });


            // Feature entity
            modelBuilder.Entity<Feature>(entity =>
            {
                entity.HasKey(f => f.Id);
                entity.Property(f => f.Name).IsRequired().HasMaxLength(100);
            });
            // تنظیمات برای ProductStock
            modelBuilder.Entity<ProductStock>(entity =>
            {
                entity.HasKey(ps => ps.Id);
                entity.Property(ps => ps.TotalStock).IsRequired();

                // ارتباط با Product
                entity.HasOne(ps => ps.Product)
                    .WithMany(p => p.ProductStocks)
                    .HasForeignKey(ps => ps.ProductId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction); // جلوگیری از Cascade Delete;

                // ارتباط با ProductVariant
                entity.HasOne(ps => ps.ProductVariant)
                    .WithMany(pv => pv.ProductStocks)  // یک ProductVariant ممکن است چندین موجودی داشته باشد
                    .HasForeignKey(ps => ps.ProductVariantId)
                    .IsRequired();
            });

            // تنظیمات برای FeatureDependency
            // تنظیمات برای FeatureDependency
            modelBuilder.Entity<FeatureDependency>(entity =>
            {
                entity.HasKey(fd => fd.Id); // کلید اصلی

                // ارتباط با Feature اصلی
                entity.HasOne(fd => fd.Feature)
                    .WithMany(f => f.Dependencies) // فرض می‌کنیم که ویژگی اصلی چندین وابستگی می‌تواند داشته باشد
                    .HasForeignKey(fd => fd.FeatureId) // مشخص کردن کلید خارجی
                    .OnDelete(DeleteBehavior.Restrict); // غیرفعال کردن Cascade Delete

                // ارتباط با Feature وابسته
                entity.HasOne(fd => fd.DependentFeature)
                    .WithMany(f => f.DependentFeatures) // فرض می‌کنیم که هر ویژگی وابسته چندین ویژگی می‌تواند داشته باشد
                    .HasForeignKey(fd => fd.DependentFeatureId) // کلید خارجی
                    .OnDelete(DeleteBehavior.Restrict); // غیرفعال کردن Cascade Delete
            });

            // تنظیمات برای FeatureValue
            modelBuilder.Entity<FeatureValue>(entity =>
            {
                entity.HasKey(fv => fv.Id);
                entity.Property(fv => fv.Value).IsRequired().HasMaxLength(200);

                // ارتباط با Feature
                entity.HasOne(fv => fv.Feature)
                    .WithMany(f => f.FeatureValues)
                    .HasForeignKey(fv => fv.FeatureId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction); // جلوگیری از Cascade Delete;

                // ارتباط با ProductFeature
                entity.HasMany(fv => fv.ProductFeatures)
                    .WithOne(pf => pf.FeatureValue)
                    .HasForeignKey(pf => pf.FeatureValueId)
                    .IsRequired();
            });
        }
    }
   
}
