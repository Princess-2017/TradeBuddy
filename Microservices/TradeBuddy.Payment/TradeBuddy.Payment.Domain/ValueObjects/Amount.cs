using System;

namespace TradeBuddy.Payment.Domain.ValueObjects
{
    public class Amount : IEquatable<Amount>
    {
        public decimal Value { get; }

        public Amount(decimal value)
        {
            if (value < 0)
                throw new ArgumentException("Amount cannot be negative.");

            Value = value;
        }

        public Amount Add(Amount amount)
        {
            return new Amount(Value + amount.Value);
        }

        public Amount Subtract(Amount amount)
        {
            if (Value < amount.Value)
                throw new InvalidOperationException("Cannot subtract more than the current amount.");

            return new Amount(Value - amount.Value);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Amount);
        }

        public bool Equals(Amount other)
        {
            return other != null && Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString("C"); // نمایش به صورت مالی
        }
    }
}
