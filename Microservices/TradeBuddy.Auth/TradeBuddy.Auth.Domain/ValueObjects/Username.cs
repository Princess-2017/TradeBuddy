using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Auth.Domain.ValueObjects
{
    public class Username
    {
        public string Value { get; }
        private Username() { }
        public Username(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
            {
                throw new ArgumentException("Username must be at least 3 characters long.", nameof(value));
            }

            Value = value.Trim();
        }

        public static implicit operator string(Username username) => username.Value;
        public static implicit operator Username(string username) => new(username);
    }
}
