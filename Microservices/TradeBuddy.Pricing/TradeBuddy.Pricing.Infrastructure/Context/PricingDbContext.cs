using Microsoft.EntityFrameworkCore;
using TradeBuddy.Pricing.Domain.Entities;

namespace TradeBuddy.Order.Infrastructure.Context
{
    public class PricingDbContext : DbContext
    {
        public PricingDbContext(DbContextOptions<PricingDbContext> options) : base(options)
        {
        }

        // DbSet برای موجودیت‌ها
        public DbSet<BusinessType> BusinessTypes { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<IndustryCategory> IndustryCategories { get; set; }
        public DbSet<PricingPlan> PricingPlans { get; set; }
        public DbSet<RatePlan> RatePlans { get; set; }
        public DbSet<RatePlanFeature> RatePlanFeatures { get; set; }
        public DbSet<ServicePackage> ServicePackages { get; set; }
        public DbSet<ServicePackageItem> ServicePackageItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // تنظیمات پیش‌فرض برای همه موجودیت‌ها
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var entity = modelBuilder.Entity(entityType.Name);

                // مقدار پیش‌فرض CreatedAt: تاریخ فعلی
                entity.Property<DateTime>("CreatedAt")
                      .HasDefaultValueSql("GETDATE()");

                // مقدار پیش‌فرض UpdatedAt: تاریخ فعلی
                entity.Property<DateTime>("UpdatedAt")
                      .HasDefaultValueSql("GETDATE()");

                // مقدار پیش‌فرض IsDeleted: false
                entity.Property<bool>("IsDeleted")
                      .HasDefaultValue(false);

                // مقدار پیش‌فرض IsActive: true (در صورت وجود)
                if (entity.Metadata.FindProperty("IsActive") != null)
                {
                    entity.Property<bool>("IsActive")
                          .HasDefaultValue(true);
                }
            }

            // تنظیمات خاص برای هر موجودیت
            ConfigureBusinessType(modelBuilder);
            ConfigureDiscount(modelBuilder);
            ConfigureIndustryCategory(modelBuilder);
            ConfigurePricingPlan(modelBuilder);
            ConfigureRatePlan(modelBuilder);
            ConfigureRatePlanFeature(modelBuilder);
            ConfigureServicePackage(modelBuilder);
            ConfigureServicePackageItem(modelBuilder);
        }

        private void ConfigureBusinessType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessType>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
            });
        }

        private void ConfigureDiscount(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discount>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
            });
        }

        private void ConfigureIndustryCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IndustryCategory>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
            });
        }

        private void ConfigurePricingPlan(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PricingPlan>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
            });
        }

        private void ConfigureRatePlan(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RatePlan>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
            });
        }

        private void ConfigureRatePlanFeature(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RatePlanFeature>(entity =>
            {
                entity.Property(e => e.FeatureName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.FeatureValue).HasMaxLength(500);
            });
        }

        private void ConfigureServicePackage(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServicePackage>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
            });
        }

        private void ConfigureServicePackageItem(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServicePackageItem>(entity =>
            {
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.AdditionalPrice).HasDefaultValue(0);
            });
        }
    }
}

