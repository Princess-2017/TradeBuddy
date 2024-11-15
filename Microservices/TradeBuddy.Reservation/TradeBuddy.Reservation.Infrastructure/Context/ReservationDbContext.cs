using Microsoft.EntityFrameworkCore;
using TradeBuddy.Reservation.Domain.Entities;
using TradeBuddy.Reservation.Domain.ValueObjects;

namespace TradeBuddy.Reservation.Infrastructure.Context
{
    public class ReservationDbContext : DbContext
    {
        public ReservationDbContext(DbContextOptions<ReservationDbContext> options) : base(options) { }

        public DbSet<TradeBuddy.Reservation.Domain.Entities.Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TradeBuddy.Reservation.Domain.Entities.Reservation>(entity =>
            {
                // Set the key for the entity
                entity.HasKey(r => r.Id);

                // Convert ReservationId to Guid
                entity.Property(r => r.Id)
                    .HasConversion(
                        reservationId => reservationId.Value,  // Convert ReservationId to Guid
                        value => new ReservationId(value)      // Convert Guid back to ReservationId
                    )
                    .IsRequired();

                // Convert other value objects to Guid
                entity.Property(r => r.CustomerId)
                    .HasConversion(customerId => customerId.Value, value => new CustomerId(value))
                    .IsRequired()
                    .HasColumnName("CustomerId");

                entity.Property(r => r.ServiceId)
                    .HasConversion(serviceId => serviceId.Value, value => new ServiceId(value))
                    .IsRequired()
                    .HasColumnName("ServiceId");

                entity.Property(r => r.BranchId)
                    .HasConversion(branchId => branchId.Value, value => new BranchId(value))
                    .IsRequired()
                    .HasColumnName("BranchId");

                // Convert ReservationStatus (Value Object) to string
                entity.Property(r => r.Status)
                    .HasConversion(
                        status => status.ToString(),  // Convert ReservationStatus to string
                        value => ReservationStatus.FromString(value) // Use the FromString method to convert string back to ReservationStatus
                    )
                    .IsRequired();

                // Map other properties
                entity.Property(r => r.ReservationDate)
                    .IsRequired();
            });
        }
    }
}
