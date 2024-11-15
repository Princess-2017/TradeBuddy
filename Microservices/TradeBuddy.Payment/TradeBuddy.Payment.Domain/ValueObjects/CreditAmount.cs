using System;

namespace TradeBuddy.Payment.Domain.ValueObjects
{
    public class CreditAmount : IEquatable<CreditAmount>
    {
        public decimal Value { get; }

        public CreditAmount(decimal value)
        {
            if (value < 0)
                throw new ArgumentException("Credit amount cannot be negative.");

            Value = value;
        }

        public CreditAmount Add(CreditAmount amount)
        {
            return new CreditAmount(Value + amount.Value);
        }

        public CreditAmount Subtract(CreditAmount amount)
        {
            if (Value < amount.Value)
                throw new InvalidOperationException("Cannot subtract more than the current credit amount.");

            return new CreditAmount(Value - amount.Value);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as CreditAmount);
        }

        public bool Equals(CreditAmount other)
        {
            return other != null && Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString("C");
        }
    }
}
