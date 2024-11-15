using System;

namespace TradeBuddy.Store.Domain.ValueObjects
{
    public class BrandName
    {
        public string Value { get; }

        public BrandName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("BrandName cannot be empty.");

            Value = value;
        }

        // Parameterless constructor for EF Core
        private BrandName() { }
    }
}
