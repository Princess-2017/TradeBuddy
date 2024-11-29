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
        public DbSet<WorkingDay> WorkingDays { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<TradeBuddy.Business.Domain.Entities.BusinessCategory> BusinessCategories { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<BusinessType> BusinessTypes { get; set; }

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
                    .HasForeignKey(b => b.BusinessTypeId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(b => b.BusinessCategory)
                    .WithMany(c => c.Businesses)
                    .HasForeignKey(b => b.BusinessCategoryId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(b => b.State)
                    .WithMany()
                    .HasForeignKey(b => b.StateId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.Property(b => b.IsDeleted).HasDefaultValue(false);
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

                entity.Property(bc => bc.IsDeleted)
                    .HasDefaultValue(false);
            });

            // Service entity configuration
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
                    .HasForeignKey(s => s.BusinessId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.OwnsMany(s => s.ServiceLocationTypes, sa =>
                {
                    sa.WithOwner().HasForeignKey("ServiceId");
                    sa.Property(l => l.LocationType).IsRequired();
                });
            });

            // BusinessHours entity configuration
            modelBuilder.Entity<BusinessHours>(entity =>
            {
                // Setting the primary key to Id
                entity.HasKey(bh => bh.Id);

                // Relationship with Business (BusinessId is the foreign key)
                entity.HasOne(bh => bh.Business)
                    .WithOne() // Assuming each BusinessHours is associated with one Business
                    .HasForeignKey<BusinessHours>(bh => bh.BusinessId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Relationship with WorkingDays (one BusinessHours can have multiple WorkingDays)
                entity.HasMany(bh => bh.WorkingDays)
                    .WithOne()
                    .HasForeignKey(wd => wd.BusinessId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Relationship with TimeSlots (one BusinessHours can have multiple TimeSlots)
                entity.HasMany(bh => bh.TimeSlots)
                    .WithOne(ts => ts.BusinessHours)
                    .HasForeignKey(ts => ts.BusinessHoursId)  // Assuming BusinessHoursId is the FK in TimeSlot
                    .OnDelete(DeleteBehavior.Cascade);
            });


            // WorkingDay entity configuration
            modelBuilder.Entity<WorkingDay>(entity =>
            {
                entity.HasKey(wd => wd.Id);

                entity.HasIndex(wd => new { wd.BusinessId, wd.Date }).IsUnique();

                entity.Property(wd => wd.Date)
                    .IsRequired();

                entity.Property(wd => wd.IsOpen)
                    .IsRequired();

                entity.HasOne<TradeBuddy.Business.Domain.Entities.Business>()
                    .WithMany(b => b.WorkingDays)
                    .HasForeignKey(wd => wd.BusinessId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // TimeSlot entity configuration
            modelBuilder.Entity<TimeSlot>(entity =>
            {
                entity.HasKey(ts => ts.Id);
                entity.OwnsOne(ts => ts.StartTime);
                entity.OwnsOne(ts => ts.EndTime);

                // Correct the relationship to BusinessHours
                entity.HasOne(ts => ts.BusinessHours)
                    .WithMany(bh => bh.TimeSlots)
                    .HasForeignKey(ts => ts.BusinessHoursId)  // Ensure this foreign key exists in TimeSlot
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Soft Delete filters
            modelBuilder.Entity<TradeBuddy.Business.Domain.Entities.Business>()
                .HasQueryFilter(b => !b.IsDeleted);

            modelBuilder.Entity<TradeBuddy.Business.Domain.Entities.Service>()
                .HasQueryFilter(s => !s.IsDeleted);

            modelBuilder.Entity<TradeBuddy.Business.Domain.Entities.BusinessCategory>()
                .HasQueryFilter(bc => !bc.IsDeleted);

            // Indexes
            modelBuilder.Entity<TradeBuddy.Business.Domain.Entities.Business>()
                .HasIndex(b => new { b.BusinessTypeId, b.BusinessCategoryId, b.StateId })
                .HasDatabaseName("IX_BusinessType_Category_State");

            modelBuilder.Entity<TradeBuddy.Business.Domain.Entities.Service>()
                .HasIndex(s => new { s.ServiceName, s.Price })
                .HasDatabaseName("IX_ServiceName_Price");

            modelBuilder.Entity<State>()
                .HasIndex(s => s.Name)
                .IsUnique();

            modelBuilder.Entity<City>()
                .HasIndex(c => new { c.Name, c.StateId })
                .HasDatabaseName("IX_City_Name_State");
        }
    }
}
