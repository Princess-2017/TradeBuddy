using TradeBuddy.Appointment.Domain.ValueObjects;

namespace TradeBuddy.Appointment.Domain.Entities
{
    public class Appointment : BaseEntity<AppointmentId>
    {
        public virtual BusinessId BusinessId { get; private set; }
        public virtual CustomerId CustomerId { get; private set; }
        public virtual Time Time { get; private set; }
        public DateTime AppointmentDate { get; private set; }
        public AppointmentStatus Status { get; private set; }

        // Constructor for creating a new Appointment
        public Appointment(
            BusinessId businessId,
            CustomerId customerId,
            Time time,
            DateTime appointmentDate,
            AppointmentStatus status)
        {
            BusinessId = businessId;
            CustomerId = customerId;
            Time = time;
            AppointmentDate = appointmentDate;
            Status = status;
        }

        // Parameterless constructor for EF Core
        private Appointment() { }

        // Method for updating an appointment
        public void Update(
            BusinessId businessId,
            CustomerId customerId,
            Time time,
            DateTime appointmentDate,
            AppointmentStatus status)
        {
            BusinessId = businessId;
            CustomerId = customerId;
            Time = time;
            AppointmentDate = appointmentDate;
            Status = status;
        }
    }
}
