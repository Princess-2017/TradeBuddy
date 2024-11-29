using System;

namespace TradeBuddy.Payment.Domain.ValueObjects
{
    public class TransactionId : IEquatable<TransactionId>
    {
        public Guid Value { get; }

        public TransactionId(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("Transaction ID cannot be empty.", nameof(value));

            Value = value;
        }

        public override bool Equals(object obj) => Equals(obj as TransactionId);
        public bool Equals(TransactionId other) => other != null && Value.Equals(other.Value);
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
    }

}
