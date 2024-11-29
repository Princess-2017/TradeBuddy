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
        public DbSet<TradeBuddy.Review.Domain.Entities.LikeDislike> LikeDislikes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TradeBuddy.Review.Domain.Entities.Review>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<TradeBuddy.Review.Domain.Entities.Review>()
                .Property(r => r.Comment)
                .HasMaxLength(1000)
                .IsRequired(false);  // Make Comment optional (can be null)

            modelBuilder.Entity<TradeBuddy.Review.Domain.Entities.Review>()
                .HasIndex(r => r.BusinessId); // Index for faster searches by BusinessId

            modelBuilder.Entity<TradeBuddy.Review.Domain.Entities.Review>()
                .HasIndex(r => r.UserId); // Index for searching reviews by UserId

            modelBuilder.Entity<TradeBuddy.Review.Domain.Entities.Review>()
                .Property(r => r.CreateDate)
                .HasDefaultValueSql("GETUTCDATE()");  // Set default to current UTC time

            modelBuilder.Entity<TradeBuddy.Review.Domain.Entities.Review>()
                .Property(r => r.UpdateDate)
                .HasDefaultValueSql("GETUTCDATE()");  // Set default to current UTC time

            modelBuilder.Entity<TradeBuddy.Review.Domain.Entities.Review>()
                .Property(r => r.IsDeleted)
                .HasDefaultValue(false);  // Default value for IsDeleted is false

            modelBuilder.Entity<TradeBuddy.Review.Domain.Entities.Review>()
                .Property(r => r.DeleteDate)
                .HasDefaultValue(null);  // Default value for DeleteDate is null

            // Configure the Rating value object to be part of Review entity
            modelBuilder.Entity<TradeBuddy.Review.Domain.Entities.Review>()
                .OwnsOne(r => r.Rating);

            // Configure the LikeDislike navigation property and relationship
            modelBuilder.Entity<TradeBuddy.Review.Domain.Entities.LikeDislike>()
                .HasKey(ld => new { ld.ReviewId, ld.UserId }); // Composite key for ReviewId and UserId
            modelBuilder.Entity<TradeBuddy.Review.Domain.Entities.LikeDislike>()
                .HasOne(ld => ld.Review)
                .WithMany(r => r.LikeDislikes)
                .HasForeignKey(ld => ld.ReviewId);

            // Configure the Review to have a "soft delete" concept using IsDeleted and DeleteDate
            modelBuilder.Entity<TradeBuddy.Review.Domain.Entities.Review>()
                .HasQueryFilter(r => !r.IsDeleted); // Global query filter to exclude soft-deleted reviews by default

            // Additional indexes for performance optimization
            modelBuilder.Entity<TradeBuddy.Review.Domain.Entities.Review>()
                .HasIndex(r => new { r.BusinessId, r.UserId });  // Composite index for faster lookups by BusinessId and UserId

            modelBuilder.Entity<TradeBuddy.Review.Domain.Entities.LikeDislike>()
                .HasIndex(ld => new { ld.ReviewId, ld.UserId });  // Index for fast lookups by ReviewId and UserId

            // Index on IsDeleted to optimize queries that filter on this property (e.g., finding deleted reviews)
            modelBuilder.Entity<TradeBuddy.Review.Domain.Entities.Review>()
                .HasIndex(r => r.IsDeleted);

            base.OnModelCreating(modelBuilder);
        }
    }
}
