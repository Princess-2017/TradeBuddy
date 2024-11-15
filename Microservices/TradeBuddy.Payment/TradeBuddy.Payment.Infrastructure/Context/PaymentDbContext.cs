using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TradeBuddy.Payment.Domain.Entities;
using TradeBuddy.Payment.Domain.ValueObjects;

namespace TradeBuddy.Payment.Infrastructure.Context
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options) { }

        public DbSet<Credit> Credits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Value converter برای CreditId
            var creditIdConverter = new ValueConverter<CreditId, Guid>(
                v => v.Value,
                v => new CreditId(v)
            );

            // Value converter برای CreditAmount
            var creditAmountConverter = new ValueConverter<CreditAmount, decimal>(
                v => v.Value,
                v => new CreditAmount(v)
            );

            // Value converter برای UserId
            var userIdConverter = new ValueConverter<UserId, Guid>(
                v => v.Value,
                v => new UserId(v)
            );

            // Fluent API configurations برای Credit entity
            modelBuilder.Entity<Credit>(entity =>
            {
                entity.HasKey(c => c.Id);

                // تنظیمات برای Id با استفاده از value converter
                entity.Property(c => c.Id)
                    .HasConversion(creditIdConverter)
                    .IsRequired();

                // تنظیمات برای UserId با استفاده از value converter
                entity.Property(c => c.UserId)
                    .HasConversion(userIdConverter)
                    .IsRequired();

                // تنظیمات برای Amount با استفاده از value converter
                entity.Property(c => c.Amount)
                    .HasConversion(creditAmountConverter)
                    .IsRequired();
            });
        }
    }
}
