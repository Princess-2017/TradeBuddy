using Microsoft.EntityFrameworkCore;
namespace TradeBuddy.Business.Infrastructure.Context;

public class BusinessDbContext : DbContext
{
    public BusinessDbContext(DbContextOptions<BusinessDbContext> options) : base(options) { }

    public DbSet<TradeBuddy.Business.Domain.Entities.Business> Businesses { get; set; }
    public DbSet<TradeBuddy.Business.Domain.Entities.Service> Services { get; set; }
    public DbSet<TradeBuddy.Business.Domain.Entities.BusinessHours> BusinessHours { get; set; }
    public DbSet<TradeBuddy.Business.Domain.Entities.WorkingDay> WorkingDays { get; set; }
    public DbSet<TimeSlot> TimeSlots { get; set; }
    public DbSet<TradeBuddy.Business.Domain.Entities.BusinessCategory> BusinessCategories { get; set; } // Add BusinessCategory DbSet

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Business entity configuration
        modelBuilder.Entity<TradeBuddy.Business.Domain.Entities.Business>(entity =>
        {
            entity.HasKey(b => b.Id);

            entity.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(b => b.Description)
                .HasMaxLength(500);

            entity.HasOne(b => b.BusinessType)
                .WithMany()
                .HasForeignKey(b => b.BusinessTypeId);

            entity.HasOne(b => b.BusinessCategory)
                .WithMany(c => c.Businesses)
                .HasForeignKey(b => b.BusinessCategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(b => b.Services)
                .WithOne()
                .HasForeignKey(s => s.BusinessId);
        });

        // BusinessCategory entity configuration
        modelBuilder.Entity<TradeBuddy.Business.Domain.Entities.BusinessCategory>(entity =>
        {
            entity.HasKey(bc => bc.Id);

            entity.Property(bc => bc.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(bc => bc.Description)
                .HasMaxLength(500);
        });

        // Other configurations remain unchanged
        modelBuilder.Entity<TradeBuddy.Business.Domain.Entities.Service>(entity =>
        {
            entity.HasKey(s => s.Id);

            entity.Property(s => s.ServiceName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(s => s.Price)
                .HasPrecision(18, 2);

            entity.HasOne<TradeBuddy.Business.Domain.Entities.Business>()
                .WithMany()
                .HasForeignKey(s => s.BusinessId);

            entity.OwnsMany(s => s.ServiceLocationTypes, sa =>
            {
                sa.WithOwner().HasForeignKey("ServiceId");
                sa.Property(l => l.LocationType).IsRequired();
            });
        });

        modelBuilder.Entity<TradeBuddy.Business.Domain.Entities.BusinessHours>(entity =>
        {
            entity.HasKey(bh => bh.BusinessId);
            entity.HasMany(bh => bh.WorkingDays)
                .WithOne()
                .HasForeignKey(wd => wd.BusinessId);
        });

        modelBuilder.Entity<TradeBuddy.Business.Domain.Entities.WorkingDay>(entity =>
        {
            entity.HasKey(wd => new { wd.BusinessId, wd.Day });
        });

        modelBuilder.Entity<TimeSlot>(entity =>
        {
            entity.HasKey(ts => ts.Id);
            entity.OwnsOne(ts => ts.StartTime);
            entity.OwnsOne(ts => ts.EndTime);
        });
    }
}
