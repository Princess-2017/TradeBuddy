using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Auth.Domain.ValueObjects
{
    public class FirstName
    {
        public string Value { get; }
        private FirstName() { }
        public FirstName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("First name is required.", nameof(value));
            }

            Value = value.Trim();
        }

        public static implicit operator string(FirstName firstName) => firstName.Value;
        public static implicit operator FirstName(string firstName) => new(firstName);
    }
}
