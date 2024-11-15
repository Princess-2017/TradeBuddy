using System;

namespace TradeBuddy.Order.Domain.ValueObjects
{
    public class OrderItemId
    {
        public Guid Value { get; private set; }

        public OrderItemId(Guid value)
        {
            Value = value;
        }

        // Implicit conversions to and from Guid
        public static implicit operator Guid(OrderItemId orderItemId) => orderItemId.Value;
        public static implicit operator OrderItemId(Guid guid) => new OrderItemId(guid);

        public override string ToString() => Value.ToString();
    }
}
