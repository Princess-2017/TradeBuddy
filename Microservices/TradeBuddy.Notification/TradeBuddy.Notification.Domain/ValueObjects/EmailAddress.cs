using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Notification.Domain.ValueObjects
{
    public class EmailAddress
    {
        public string Value { get; private set; }

        public EmailAddress(string value)
        {
            // اعتبارسنجی ایمیل می‌تواند در اینجا انجام شود
            Value = value;
        }
    }
}
