using System;

namespace TradeBuddy.Payment.Domain.ValueObjects
{
    public class TransactionId : IEquatable<TransactionId>
    {
        public Guid Value { get; }

        public TransactionId(Guid value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TransactionId);
        }

        public bool Equals(TransactionId other)
        {
            return other != null && Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
