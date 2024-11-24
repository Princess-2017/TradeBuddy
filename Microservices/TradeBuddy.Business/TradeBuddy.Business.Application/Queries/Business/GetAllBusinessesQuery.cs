using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Business.Application.Dto;

namespace TradeBuddy.Business.Application.Queries.Business
{
    public class GetAllBusinessesQuery : IRequest<PaginatedResult<BusinessDto>>
    {
        public int PageNumber { get; set; } = 1; // شماره صفحه
        public int PageSize { get; set; } = 10;  // تعداد آیتم‌ها در هر صفحه
    }
}
