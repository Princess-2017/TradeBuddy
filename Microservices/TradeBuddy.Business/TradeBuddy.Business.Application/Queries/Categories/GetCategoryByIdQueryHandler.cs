using AutoMapper; // فرض بر استفاده از AutoMapper برای نقشه‌برداری
using TradeBuddy.Business.Application.DTOs;
using TradeBuddy.Business.Domain.Entities;
using TradeBuddy.Business.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace TradeBuddy.Business.Application.Queries.Categories
{
    // Handler برای دریافت دسته‌بندی بر اساس شناسه
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<BusinessCategory, Guid> _businessCategoryRepository;
        private readonly IMapper _mapper;

        // سازنده کلاس که وابستگی‌ها را تزریق می‌کند
        public GetCategoryByIdQueryHandler(IRepository<BusinessCategory, Guid> businessCategoryRepository, IMapper mapper)
        {
            _businessCategoryRepository = businessCategoryRepository;
            _mapper = mapper;
        }

        // متد اصلی برای اجرای query و دریافت داده‌ها
        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            // دریافت دسته‌بندی با استفاده از شناسه از ریپازیتوری
            var category = await _businessCategoryRepository.GetByIdAsync(request.CategoryId);

            if (category == null)
            {
                return null; // اگر دسته‌بندی پیدا نشد
            }

            // نقشه‌برداری دسته‌بندی به DTO
            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }
    }
}
