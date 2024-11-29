using System;

namespace TradeBuddy.Payment.Domain.ValueObjects
{
    public class PaymentMethod : IEquatable<PaymentMethod>
    {
        public string Method { get; }

        public PaymentMethod(string method)
        {
            if (string.IsNullOrWhiteSpace(method))
                throw new ArgumentException("Payment method cannot be null or empty.", nameof(method));

            Method = method;
        }

        public override bool Equals(object obj) => Equals(obj as PaymentMethod);
        public bool Equals(PaymentMethod other) => other != null && Method == other.Method;
        public override int GetHashCode() => Method.GetHashCode();
        public override string ToString() => Method;
    }

}
