
using System;

namespace TradeBuddy.Reservation.Domain.ValueObjects
{
    public class CustomerId
    {
        public Guid Value { get; private set; }

        public CustomerId(Guid value)
        {
            Value = value;
        }

        private CustomerId() { }
        // Implicit conversions
        public static implicit operator Guid(CustomerId customerId) => customerId.Value;
        public static implicit operator CustomerId(Guid guid) => new CustomerId(guid);
    }

}
