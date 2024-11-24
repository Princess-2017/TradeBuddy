using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Business.Application.Dto
{
    public class PaginatedResult<T>
    {
        public IEnumerable<T> Items { get; set; } // آیتم‌ها در صفحه جاری
        public int TotalCount { get; set; } // تعداد کل آیتم‌ها
        public int PageNumber { get; set; } // شماره صفحه جاری
        public int PageSize { get; set; } // تعداد آیتم‌ها در هر صفحه

        public PaginatedResult(IEnumerable<T> items, int totalCount, int pageNumber, int pageSize)
        {
            Items = items;
            TotalCount = totalCount;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
