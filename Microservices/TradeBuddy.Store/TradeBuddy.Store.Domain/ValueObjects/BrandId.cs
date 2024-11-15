using System;

namespace TradeBuddy.Store.Domain.ValueObjects
{
    public class BrandId
    {
        public Guid Value { get; private set; }

        public BrandId(Guid value)
        {
            Value = value;
        }

        private BrandId() { }
    }
}
