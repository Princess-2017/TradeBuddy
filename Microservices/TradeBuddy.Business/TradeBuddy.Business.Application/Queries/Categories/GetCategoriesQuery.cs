using MediatR;
using TradeBuddy.Business.Application.DTOs;
using System.Collections.Generic;
using TradeBuddy.Business.Application.Common.mediaterdefine;

namespace TradeBuddy.Business.Application.Queries.Categories
{
    // کلاس برای ارسال درخواست به MediatR
    public class GetCategoriesQuery : IQuery<IEnumerable<CategoryDto>>
    {
    }
}
