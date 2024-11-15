using System;

namespace TradeBuddy.Store.Domain.ValueObjects
{
    public class CategoryName
    {
        public string Value { get; }

        public CategoryName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("CategoryName cannot be empty.");

            Value = value;
        }
        private CategoryName() { }
    }
}
