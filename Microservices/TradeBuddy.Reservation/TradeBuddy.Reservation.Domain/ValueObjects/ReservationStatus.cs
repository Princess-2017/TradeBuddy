namespace TradeBuddy.Reservation.Domain.ValueObjects
{
    public class ReservationStatus
    {
        public string Status { get; private set; }

        // وضعیت‌های مختلف
        public static ReservationStatus Pending => new ReservationStatus("Pending");
        public static ReservationStatus Confirmed => new ReservationStatus("Confirmed");
        public static ReservationStatus Canceled => new ReservationStatus("Canceled");
        public static ReservationStatus Completed => new ReservationStatus("Completed");

        private ReservationStatus(string status)
        {
            Status = status;
        }

        // متد استاتیک برای ساخت از string
        public static ReservationStatus FromString(string status)
        {
            return status switch
            {
                "Pending" => Pending,
                "Confirmed" => Confirmed,
                "Canceled" => Canceled,
                "Completed" => Completed,
                _ => throw new ArgumentException("Invalid status value", nameof(status)),
            };
        }

        public override string ToString() => Status;

        public override bool Equals(object obj)
        {
            return obj is ReservationStatus status && Status == status.Status;
        }

        public override int GetHashCode()
        {
            return Status.GetHashCode();
        }
    }
}
