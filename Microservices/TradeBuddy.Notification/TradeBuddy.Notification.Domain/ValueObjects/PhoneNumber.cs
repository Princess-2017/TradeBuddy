using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Notification.Domain.ValueObjects
{
    public class PhoneNumber
    {
        public string Value { get; private set; }

        public PhoneNumber(string value)
        {
            // اعتبارسنجی شماره تلفن می‌تواند در اینجا انجام شود
            Value = value;
        }
    }
}
