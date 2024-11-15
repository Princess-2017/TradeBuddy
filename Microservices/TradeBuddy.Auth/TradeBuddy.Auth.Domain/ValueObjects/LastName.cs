using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Auth.Domain.ValueObjects
{
    public class LastName
    {
        public string Value { get; }
        private LastName () { }
        public LastName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Last name is required.", nameof(value));
            }

            Value = value.Trim();
        }

        public static implicit operator string(LastName lastName) => lastName.Value;
        public static implicit operator LastName(string lastName) => new(lastName);
    }
}
