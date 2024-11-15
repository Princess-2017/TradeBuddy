using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TradeBuddy.Auth.Domain.ValueObjects;

namespace TradeBuddy.Auth.Domain.ValueObjects
{
    public class Email
    {
        public string Value { get; }
        private Email () { }
        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !IsValidEmail(value))
            {
                throw new ArgumentException("Invalid email address.", nameof(value));
            }

            Value = value.Trim();
        }

        private bool IsValidEmail(string email)
        {
            // ساده‌ترین الگوی اعتبارسنجی برای ایمیل
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return regex.IsMatch(email);
        }


        public static implicit operator string(Email email) => email.Value;
        public static implicit operator Email(string email) => new(email);
    }
}
