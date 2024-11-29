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
        public DbSet<TradeBuddy.Payment.Domain.Entities.Payment> Payments { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // تعریف ValueConverter ها برای ValueObject ها
            var userIdConverter = new ValueConverter<UserId, Guid>(
                v => v.Value,  // تبدیل UserId به Guid برای ذخیره در پایگاه داده
                v => new UserId(v) // تبدیل Guid به UserId برای استفاده در کد
            );

            var amountConverter = new ValueConverter<Amount, decimal>(
                v => v.Value,
                v => new Amount(v)
            );

            var creditAmountConverter = new ValueConverter<CreditAmount, decimal>(
                v => v.Value,
                v => new CreditAmount(v)
            );

            var transactionIdConverter = new ValueConverter<TransactionId, Guid>(
                v => v.Value,
                v => new TransactionId(v)
            );

            var paymentMethodConverter = new ValueConverter<PaymentMethod, string>(
                v => v.Method,
                v => new PaymentMethod(v)
            );

            var paymentStatusConverter = new ValueConverter<PaymentStatus, string>(
                v => v.Status,
                v => new PaymentStatus(v)
            );

            // تعریف نگاشت‌ها برای موجودیت‌ها
            ConfigureCreditEntity(modelBuilder, userIdConverter, creditAmountConverter);
            ConfigurePaymentEntity(modelBuilder, amountConverter, paymentMethodConverter, transactionIdConverter, paymentStatusConverter);
            ConfigureWalletEntity(modelBuilder, userIdConverter, amountConverter);
        }

        private void ConfigureCreditEntity(
            ModelBuilder modelBuilder,
            ValueConverter<UserId, Guid> userIdConverter,
            ValueConverter<CreditAmount, decimal> creditAmountConverter)
        {
            modelBuilder.Entity<Credit>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.UserId)
                    .HasConversion(userIdConverter)
                    .IsRequired();

                entity.Property(c => c.Amount)
                    .HasConversion(creditAmountConverter)
                    .IsRequired();

                entity.Property(c => c.CreateDate)
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(c => c.IsDeleted)
                    .HasDefaultValue(false);

                // تنظیم فیلتر برای حذف منطقی
                entity.HasQueryFilter(c => !c.IsDeleted);
            });
        }

        private void ConfigurePaymentEntity(
            ModelBuilder modelBuilder,
            ValueConverter<Amount, decimal> amountConverter,
            ValueConverter<PaymentMethod, string> paymentMethodConverter,
            ValueConverter<TransactionId, Guid> transactionIdConverter,
            ValueConverter<PaymentStatus, string> paymentStatusConverter)
        {
            modelBuilder.Entity<TradeBuddy.Payment.Domain.Entities.Payment>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Amount)
                    .HasConversion(amountConverter)
                    .IsRequired();

                entity.Property(p => p.PaymentMethod)
                    .HasConversion(paymentMethodConverter)
                    .IsRequired();

                entity.Property(p => p.TransactionId)
                    .HasConversion(transactionIdConverter)
                    .IsRequired();

                entity.Property(p => p.Status)
                    .HasConversion(paymentStatusConverter)
                    .IsRequired();

                entity.Property(p => p.PaymentDate)
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(p => p.CreateDate)
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(p => p.IsDeleted)
                    .HasDefaultValue(false);

                // تنظیم فیلتر برای حذف منطقی
                entity.HasQueryFilter(p => !p.IsDeleted);
            });
        }

        private void ConfigureWalletEntity(
            ModelBuilder modelBuilder,
            ValueConverter<UserId, Guid> userIdConverter,
            ValueConverter<Amount, decimal> amountConverter)
        {
            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.HasKey(w => w.Id);

                entity.Property(w => w.UserId)
                    .HasConversion(userIdConverter)
                    .IsRequired();

                entity.Property(w => w.Balance)
                    .HasConversion(amountConverter)
                    .IsRequired();

                entity.Property(w => w.CreateDate)
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(w => w.IsDeleted)
                    .HasDefaultValue(false);

                // تنظیم فیلتر برای حذف منطقی
                entity.HasQueryFilter(w => !w.IsDeleted);
            });
        }
    }
}
