using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TradeBuddy.Order.Domain.Entities;
using TradeBuddy.Order.Domain.ValueObjects;

namespace TradeBuddy.Order.Infrastructure.Context
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

        public DbSet<TradeBuddy.Order.Domain.Entities.Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API configurations for Order entity
            modelBuilder.Entity<TradeBuddy.Order.Domain.Entities.Order>(entity =>
            {
                entity.HasKey(o => o.Id);

                // Configure the Id property to use the value converter
                entity.Property(o => o.Id)
                    .IsRequired();

                entity.Property(o => o.OrderDate)
                    .IsRequired();

                entity.Property(o => o.TotalAmount)
                    .HasPrecision(18, 2)
                    .IsRequired();

                entity.Property(o => o.CustomerId)
                    .IsRequired();

                entity.Property(o => o.Status)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(o => o.OrderType)
                    .IsRequired()
                    .HasMaxLength(10);

                // Configure the relationship with OrderItems
                entity.HasMany(o => o.Items)
                    .WithOne()
                    .HasForeignKey(oi => oi.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Fluent API configurations for OrderItem entity
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(oi => oi.Id);

                // Configure the Id property to use the value converter
                entity.Property(oi => oi.Id)
                    .IsRequired();

                entity.Property(oi => oi.ProductId)
                    .IsRequired();

                entity.Property(oi => oi.Quantity)
                    .IsRequired();

                entity.Property(oi => oi.UnitPrice)
                    .HasPrecision(18, 2)
                    .IsRequired();

                entity.Property(oi => oi.Tax)
                    .HasPrecision(18, 2)
                    .IsRequired();

                entity.Property(oi => oi.Insurance)
                    .HasPrecision(18, 2)
                    .IsRequired();

                entity.Property(oi => oi.ServiceDuration)
                    .IsRequired(false);
            });
        }
    }
}
