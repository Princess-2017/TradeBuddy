using System;

namespace TradeBuddy.Store.Domain.ValueObjects
{
    public class ProductName
    {
        public string Value { get; }

        public ProductName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("ProductName cannot be empty.");

            Value = value;
        }
        private ProductName() { }
    }
}
