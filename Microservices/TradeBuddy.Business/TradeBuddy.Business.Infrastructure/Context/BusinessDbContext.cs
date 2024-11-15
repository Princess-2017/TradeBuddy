using Microsoft.EntityFrameworkCore;
using TradeBuddy.Business.Domain.Entities;
using TradeBuddy.Business.Domain.ValueObjects;

namespace TradeBuddy.Business.Infrastructure.Context
{
    public class BusinessDbContext : DbContext
    {
        public BusinessDbContext(DbContextOptions<BusinessDbContext> options) : base(options) { }

        public DbSet<TradeBuddy.Business.Domain.Entities.Business> Businesses { get; set; }
        public DbSet<TradeBuddy.Business.Domain.Entities.Service> Services { get; set; }
        public DbSet<TradeBuddy.Business.Domain.Entities.BusinessHours> BusinessHours { get; set; }
        public DbSet<TradeBuddy.Business.Domain.Entities.WorkingDay> WorkingDays { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API configurations for Business entity
            modelBuilder.Entity<TradeBuddy.Business.Domain.Entities.Business>(entity =>
            {
                entity.HasKey(b => b.Id);

                entity.Property(b => b.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(b => b.Description)
                    .HasMaxLength(500);

                entity.HasMany(b => b.Services)
                    .WithOne()
                    .HasForeignKey(s => s.BusinessId);
            });

            // Fluent API configurations for Service entity
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

                // Configure ServiceLocationType as an owned entity
                entity.OwnsMany(s => s.ServiceLocationTypes, sa =>
                {
                    sa.WithOwner().HasForeignKey("ServiceId"); // This establishes the foreign key relationship
                    sa.Property(l => l.LocationType).IsRequired(); // Configure LocationType property
                });
            });

            // Fluent API configurations for BusinessHours, WorkingDay, and TimeSlot entities remain unchanged
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
}
