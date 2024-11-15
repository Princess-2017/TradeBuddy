using System;

namespace TradeBuddy.Payment.Domain.ValueObjects
{
    public class UserId : IEquatable<UserId>
    {
        public Guid Value { get; }

        public UserId(Guid value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as UserId);
        }

        public bool Equals(UserId other)
        {
            return other != null && Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
