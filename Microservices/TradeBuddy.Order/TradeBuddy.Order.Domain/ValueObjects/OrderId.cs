using System;

namespace TradeBuddy.Order.Domain.ValueObjects
{
    public class OrderId
    {
        public Guid Value { get; private set; }

        public OrderId(Guid value)
        {
            Value = value;
        }

        // For EF Core to work with this type, you need implicit conversions.
        public static implicit operator Guid(OrderId orderId) => orderId.Value;
        public static implicit operator OrderId(Guid guid) => new OrderId(guid);

        public override string ToString() => Value.ToString();
    }
}
