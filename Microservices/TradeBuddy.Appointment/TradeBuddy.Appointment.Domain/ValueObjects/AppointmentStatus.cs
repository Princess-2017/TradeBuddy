using System;

namespace TradeBuddy.Appointment.Domain.ValueObjects
{
    public class AppointmentStatus
    {
        public string Status { get; private set; }

        // Change the constructor to public
        public AppointmentStatus(string status)
        {
            Status = status;
        }

        public static AppointmentStatus Scheduled => new AppointmentStatus("Scheduled");
        public static AppointmentStatus Confirmed => new AppointmentStatus("Confirmed");
        public static AppointmentStatus Canceled => new AppointmentStatus("Canceled");
        public static AppointmentStatus Completed => new AppointmentStatus("Completed");
        public static AppointmentStatus NoShow => new AppointmentStatus("NoShow");

        public override string ToString() => Status;

        public override bool Equals(object obj) =>
            obj is AppointmentStatus other && Status == other.Status;

        public override int GetHashCode() => Status.GetHashCode();

        // Keep the parameterless constructor private for EF Core usage
        private AppointmentStatus() { }

        // Method to convert a string to AppointmentStatus
        public static AppointmentStatus FromString(string status)
        {
            return status switch
            {
                "Scheduled" => Scheduled,
                "Confirmed" => Confirmed,
                "Canceled" => Canceled,
                "Completed" => Completed,
                "NoShow" => NoShow,
                _ => throw new ArgumentException("Invalid appointment status")
            };
        }
    }
}
