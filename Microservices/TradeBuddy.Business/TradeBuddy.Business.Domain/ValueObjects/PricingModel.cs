using System;

namespace TradeBuddy.Business.Domain.ValueObjects
{
    public class PricingModel : IEquatable<PricingModel>
    {
        public decimal BasePrice { get; private set; }
        public decimal? Discount { get; private set; }

        public PricingModel(decimal basePrice, decimal? discount = null)
        {
            if (basePrice < 0)
                throw new ArgumentException("Base price cannot be negative");

            BasePrice = basePrice;
            Discount = discount;
        }

        public decimal GetFinalPrice()
        {
            return Discount.HasValue ? BasePrice - (BasePrice * Discount.Value / 100) : BasePrice;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as PricingModel);
        }

        public bool Equals(PricingModel other)
        {
            return other != null &&
                   BasePrice == other.BasePrice &&
                   Discount == other.Discount;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BasePrice, Discount);
        }
    }
}
