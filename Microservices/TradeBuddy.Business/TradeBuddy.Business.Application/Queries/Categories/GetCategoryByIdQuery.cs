using System;
using TradeBuddy.Business.Application.Common.mediaterdefine;
using TradeBuddy.Business.Application.DTOs;
using TradeBuddy.Business.Application.Queries;

namespace TradeBuddy.Business.Application.Queries.Categories
{
    // تعریف GetCategoryByIdQuery که از IQuery<CategoryDto> ارث‌بری می‌کند
    public class GetCategoryByIdQuery : IQuery<CategoryDto>
    {
        public Guid CategoryId { get; set; }

        public GetCategoryByIdQuery() { }

        // سازنده که مقدار CategoryId را دریافت می‌کند
        public GetCategoryByIdQuery(Guid categoryId)
        {
            CategoryId = categoryId; // مقداردهی به ویژگی
        }
    }
}
