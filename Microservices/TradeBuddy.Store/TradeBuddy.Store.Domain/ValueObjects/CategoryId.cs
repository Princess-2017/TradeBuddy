using System;

namespace TradeBuddy.Store.Domain.ValueObjects
{
    public class CategoryId
    {
        public Guid Value { get; private set; }

        public CategoryId(Guid value)
        {
            Value = value;
        }

        private CategoryId() { }
    }
}
