using System;

namespace TradeBuddy.Payment.Domain.ValueObjects
{
    public class CreditId : IEquatable<CreditId>
    {
        public Guid Value { get; }

        public CreditId(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("CreditId cannot be an empty GUID.");

            Value = value;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as CreditId);
        }

        public bool Equals(CreditId other)
        {
            return other != null && Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
