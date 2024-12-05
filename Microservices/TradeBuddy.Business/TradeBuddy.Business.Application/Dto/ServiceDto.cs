using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Business.Application.Dto
{
    public class ServiceDto
    {
        public Guid Id { get; set; } // شناسه سرویس
        public string ServiceName { get; set; } // نام سرویس
        public decimal Price { get; set; } // قیمت سرویس
        public Guid BusinessId { get; set; } // شناسه کسب‌وکار
        public string StartTime { get; set; } // زمان شروع به فرمت HH:mm
        public string EndTime { get; set; } // زمان پایان به فرمت HH:mm
    }
}
