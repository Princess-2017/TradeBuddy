using System;

namespace TradeBuddy.Payment.Domain.ValueObjects
{
    public class PaymentId : IEquatable<PaymentId>
    {
        public Guid Value { get; }

        public PaymentId(Guid value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as PaymentId);
        }

        public bool Equals(PaymentId other)
        {
            return other != null && Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
