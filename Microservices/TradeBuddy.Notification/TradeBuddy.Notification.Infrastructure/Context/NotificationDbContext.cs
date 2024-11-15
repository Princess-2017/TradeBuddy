using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TradeBuddy.Notification.Domain.Entities;

namespace TradeBuddy.Notification.Infrastructure.Context
{
    public class NotificationDbContext : DbContext
    {
        public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options) { }
        public DbSet<TradeBuddy.Notification.Domain.Entities.Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API configurations for Notification entity
            modelBuilder.Entity<TradeBuddy.Notification.Domain.Entities.Notification>(entity =>
            {
                entity.HasKey(n => n.Id); // تنظیم کلید اصلی

                // تنظیمات برای فیلد Message
                entity.Property(n => n.Message)
                    .IsRequired()
                    .HasMaxLength(500); // تعیین حداکثر طول برای پیام

                // تنظیمات برای فیلد Email
                entity.Property(n => n.Email)
                    .IsRequired()
                    .HasMaxLength(256); // تعیین حداکثر طول برای ایمیل

                // تنظیمات برای فیلد Phone
                entity.Property(n => n.Phone)
                    .IsRequired()
                    .HasMaxLength(20); // تعیین حداکثر طول برای شماره تلفن

                // تنظیمات برای فیلد SentDate
                entity.Property(n => n.SentDate)
                    .IsRequired(); // ارسال تاریخ ضروری است

                // تنظیمات برای فیلد IsSent
                entity.Property(n => n.IsSent)
                    .IsRequired(); // وضعیت ارسال ضروری است
            });
        }
    }
}
