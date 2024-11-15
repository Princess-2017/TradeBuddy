using Microsoft.EntityFrameworkCore;
using TradeBuddy.Appointment.Domain.ValueObjects;

namespace TradeBuddy.Appointment.Infrastructure.Context
{
    public class AppointmentDbContext : DbContext
    {
        public DbSet<TradeBuddy.Appointment.Domain.Entities.Appointment> Appointments { get; set; }

        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TradeBuddy.Appointment.Domain.Entities.Appointment>(entity =>
            {
                entity.HasKey(e => e.Id);

                // Configure AppointmentId property
                entity.Property(e => e.Id)
                    .HasConversion(
                        id => id.Value, // Convert AppointmentId to Guid
                        value => new AppointmentId(value) // Convert Guid to AppointmentId
                    )
                    .IsRequired();

                // Configure BusinessId property
                entity.Property(e => e.BusinessId)
                    .HasConversion(
                        id => id.Value, // Assuming BusinessId is a Guid
                        value => new BusinessId(value) // Convert Guid to BusinessId
                    )
                    .IsRequired();

                // Configure CustomerId property
                entity.Property(e => e.CustomerId)
                    .HasConversion(
                        id => id.Value, // Assuming CustomerId is a Guid
                        value => new CustomerId(value) // Convert Guid to CustomerId
                    )
                    .IsRequired();

                // Configure Time property
                entity.Property(e => e.Time)
                    .HasConversion(
                        time => time.ToString(), // Convert Time to string for database
                        str => ConvertStringToTime(str) // Call a method for conversion
                    )
                    .IsRequired();

                // Configure AppointmentDate property
                entity.Property(e => e.AppointmentDate)
                    .IsRequired();

                // Configure Status property
                entity.Property(e => e.Status)
                    .HasConversion(
                        status => status.ToString(),
                        str => AppointmentStatus.FromString(str)
                    )
                    .IsRequired();
            });

            // Additional entity configurations...
        }

        // Method to convert string to Time object
        private Time ConvertStringToTime(string str)
        {
            var parts = str.Split(':');
            if (parts.Length != 2 ||
                !int.TryParse(parts[0], out var hour) ||
                !int.TryParse(parts[1], out var minute))
            {
                throw new FormatException($"Invalid Time format: {str}");
            }
            return new Time(hour, minute);
        }
    }
}