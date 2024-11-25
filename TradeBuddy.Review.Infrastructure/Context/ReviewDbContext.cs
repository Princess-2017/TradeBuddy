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
        public ReviewDbContext(DbContextOptions<ReviewDbContext> options) : base(options) { }

        public DbSet<TradeBuddy.Review.Domain.Entities.Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TradeBuddy.Review.Domain.Entities.Review>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<TradeBuddy.Review.Domain.Entities.Review>()
                .Property(r => r.Comment)
                .HasMaxLength(1000);

            modelBuilder.Entity<TradeBuddy.Review.Domain.Entities.Review>()
                .HasIndex(r => r.BusinessId); // Optimize searches by BusinessId

            // Configure the Rating value object to be part of Review entity
            modelBuilder.Entity<TradeBuddy.Review.Domain.Entities.Review>()
                .OwnsOne(r => r.Rating);

            base.OnModelCreating(modelBuilder);
        }
    }

}
