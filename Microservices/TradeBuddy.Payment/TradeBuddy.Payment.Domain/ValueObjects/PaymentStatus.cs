using System;

namespace TradeBuddy.Payment.Domain.ValueObjects
{
    public class PaymentStatus : IEquatable<PaymentStatus>
    {
        public string Status { get; }

        // Static readonly fields for different statuses
        public static readonly PaymentStatus Completed = new PaymentStatus("Completed");
        public static readonly PaymentStatus Failed = new PaymentStatus("Failed");
        public static readonly PaymentStatus Pending = new PaymentStatus("Pending");

        public PaymentStatus(string status)
        {
            Status = status ?? throw new ArgumentNullException(nameof(status));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as PaymentStatus);
        }

        public bool Equals(PaymentStatus other)
        {
            return other != null && Status == other.Status;
        }

        public override int GetHashCode()
        {
            return Status.GetHashCode();
        }

        public override string ToString()
        {
            return Status;
        }
    }
}
