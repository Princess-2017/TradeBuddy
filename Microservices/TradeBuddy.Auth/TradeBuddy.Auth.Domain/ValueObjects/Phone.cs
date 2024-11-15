using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Auth.Domain.ValueObjects
{
    public class Phone
    {
        public string Value { get; }
        private Phone() { }
        public Phone(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !IsValidPhone(value))
            {
                throw new ArgumentException("Invalid phone number.", nameof(value));
            }

            Value = value.Trim();
        }

        private bool IsValidPhone(string phone)
        {
            // اعتبارسنجی ساده برای شماره تلفن
            return phone.Length == 10 && long.TryParse(phone, out _);
        }

        public static implicit operator string(Phone phone) => phone.Value;
        public static implicit operator Phone(string phone) => new(phone);
    }
}
