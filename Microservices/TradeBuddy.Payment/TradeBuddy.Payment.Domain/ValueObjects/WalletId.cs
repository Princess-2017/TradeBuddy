using System;

namespace TradeBuddy.Payment.Domain.ValueObjects
{
    public class WalletId : IEquatable<WalletId>
    {
        public Guid Value { get; }

        public WalletId(Guid value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as WalletId);
        }

        public bool Equals(WalletId other)
        {
            return other != null && Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
