using Microsoft.EntityFrameworkCore;
using TradeBuddy.Customer.Domain.Entities;
using TradeBuddy.Customer.Domain.ValueObjects;

namespace TradeBuddy.Customer.Infrastructure.Context
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

        public DbSet<TradeBuddy.Customer.Domain.Entities.Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API configurations for Customer entity
            modelBuilder.Entity<TradeBuddy.Customer.Domain.Entities.Customer>(entity =>
            {
                entity.HasKey(c => c.Id);

                // تنظیمات برای فیلد FullName
                entity.Property(c => c.FullName)
                    .IsRequired()
                    .HasConversion(
                        f => f.ToString(), // تبدیل به رشته برای ذخیره‌سازی
                        f => new FullName(f)); // بازگشت به FullName از رشته

                // تنظیمات برای فیلد PhoneNumber
                entity.Property(c => c.PhoneNumber)
                    .IsRequired()
                    .HasConversion(
                        p => p.ToString(), // تبدیل به رشته برای ذخیره‌سازی
                        p => new PhoneNumber(p)); // بازگشت به PhoneNumber از رشته

                // تنظیمات برای فیلد EmailAddress
                entity.Property(c => c.EmailAddress)
                    .IsRequired()
                    .HasConversion(
                        e => e.ToString(), // تبدیل به رشته برای ذخیره‌سازی
                        e => new EmailAddress(e)); // بازگشت به EmailAddress از رشته

                // تنظیمات برای فیلد Address
                entity.Property(c => c.Address)
                    .IsRequired()
                    .HasConversion(
                        a => a.ToString(), // تبدیل به رشته برای ذخیره‌سازی
                        a => new Address(a)); // بازگشت به Address از رشته
            });
        }
    }
}
