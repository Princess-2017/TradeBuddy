
using System;
using TradeBuddy.Order.Domain.ValueObjects;

namespace TradeBuddy.Order.Domain.Entities
{
    public class OrderItem : BaseEntity<Guid>
    {
        public Guid ProductId { get; private set; } // برای کالاها
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice => Quantity * UnitPrice;
        public Guid OrderId { get; private set; }

        // ویژگی‌های جدید
        public decimal Tax { get; private set; } // مالیات
        public decimal Insurance { get; private set; } // بیمه
        public TimeSpan? ServiceDuration { get; private set; } // برای خدمات

        public OrderItem(Guid id, Guid productId, int quantity, decimal unitPrice, Guid orderId, decimal tax, decimal insurance, TimeSpan? serviceDuration = null)
        {
            Id = id;
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            OrderId = orderId;
            Tax = tax; // مقداردهی مالیات
            Insurance = insurance; // مقداردهی بیمه
            ServiceDuration = serviceDuration; // برای خدمات
        }

        public void UpdateQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}