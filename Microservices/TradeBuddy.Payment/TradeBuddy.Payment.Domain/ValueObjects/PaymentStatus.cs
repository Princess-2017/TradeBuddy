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
            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("Payment status cannot be null or empty.", nameof(status));

            Status = status;
        }

        public override bool Equals(object obj) => Equals(obj as PaymentStatus);
        public bool Equals(PaymentStatus other) => other != null && Status == other.Status;
        public override int GetHashCode() => Status.GetHashCode();
        public override string ToString() => Status;
    }

}
