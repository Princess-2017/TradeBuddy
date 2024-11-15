using System;

namespace TradeBuddy.Payment.Domain.ValueObjects
{
    public class PaymentMethod : IEquatable<PaymentMethod>
    {
        public string Method { get; }

        public PaymentMethod(string method)
        {
            Method = method ?? throw new ArgumentNullException(nameof(method));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as PaymentMethod);
        }

        public bool Equals(PaymentMethod other)
        {
            return other != null && Method == other.Method;
        }

        public override int GetHashCode()
        {
            return Method.GetHashCode();
        }

        public override string ToString()
        {
            return Method;
        }
    }
}
