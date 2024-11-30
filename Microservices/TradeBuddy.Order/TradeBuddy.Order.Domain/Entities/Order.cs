using System;
using System.Collections.Generic;
using TradeBuddy.Order.Domain.ValueObjects;

namespace TradeBuddy.Order.Domain.Entities
{
    public class Order : BaseEntity<Guid>
    {
        public DateTime OrderDate { get; private set; }
        public decimal TotalAmount { get; private set; }
        public Guid CustomerId { get; private set; }
        public int? PricingPlanId { get; set; } // پلن درآمدی مرتبط (در صورت وجود)
        public string Status { get; private set; }
        public string OrderType { get; private set; } // "Product" or "Service"

        private readonly List<OrderItem> _items = new List<OrderItem>();

        // Make the Items navigation property virtual
        public virtual IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

        public Order(Guid id, Guid customerId, DateTime orderDate, string orderType)
        {
            Id = id;
            CustomerId = customerId;
            OrderDate = orderDate;
            OrderType = orderType;
            Status = "Pending";
        }

        public void AddItem(OrderItem item)
        {
            _items.Add(item);
            TotalAmount += item.TotalPrice + item.Tax + item.Insurance; // Add tax and insurance
        }

        public void RemoveItem(OrderItem item)
        {
            _items.Remove(item);
            TotalAmount -= item.TotalPrice + item.Tax + item.Insurance; // Subtract tax and insurance
        }
        public void MarkAsDeleted()
        {
            if (IsDeleted)
                throw new InvalidOperationException("The order is already marked as deleted.");

            IsDeleted = true;
        }

        public void CompleteOrder()
        {
            Status = "Completed";
        }
    }
}
