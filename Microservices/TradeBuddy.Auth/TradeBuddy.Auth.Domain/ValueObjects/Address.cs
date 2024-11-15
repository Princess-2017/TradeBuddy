using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Auth.Domain.ValueObjects
{
    public class Address
    {
        public string Value { get; }
        private Address() { }
        public Address(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Address is required.", nameof(value));
            }

            Value = value.Trim();
        }

        public static implicit operator string(Address address) => address.Value;
        public static implicit operator Address(string address) => new(address);
    }
}
