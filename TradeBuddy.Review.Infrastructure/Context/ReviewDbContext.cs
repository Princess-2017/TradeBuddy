using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Review.Domain.Entities;

namespace TradeBuddy.Review.Infrastructure.Context
{
    public class ReviewDbContext : DbContext
    {
        public DbSet<TradeBuddy.Review.Domain.Entities.Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TradeBuddy.Review.Domain.Entities.Review>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<TradeBuddy.Review.Domain.Entities.Review>()
                .Property(r => r.Comment)
                .HasMaxLength(1000);

            modelBuilder.Entity<TradeBuddy.Review.Domain.Entities.Review>()
                .HasIndex(r => r.BusinessId); // بهینه‌سازی جستجو

            base.OnModelCreating(modelBuilder);
        }
    }

}
