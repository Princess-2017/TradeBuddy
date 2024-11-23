using MediatR;
using TradeBuddy.Business.Domain.Entities;
using TradeBuddy.Business.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace TradeBuddy.Business.Application.Commands.Categories
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Guid>
    {
        private readonly IRepository<BusinessCategory, Guid> _businessCategoryRepository;

        public AddCategoryCommandHandler(IRepository<BusinessCategory, Guid> businessCategoryRepository)
        {
             _businessCategoryRepository = businessCategoryRepository;
        }

        public async Task<Guid> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            // اعتبارسنجی ساده
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ArgumentException("نام دسته‌بندی نمی‌تواند خالی باشد.");

            // ساخت یک شیء دسته‌بندی جدید
            // ساخت یک شیء دسته‌بندی جدید
            var category = new BusinessCategory(request.Name, request.Description);

            // استفاده از جنریک ریپوزیتوری برای اضافه کردن
            await _businessCategoryRepository.AddAsync(category);

            // بازگشت شناسه دسته‌بندی ایجاد شده
            return category.Id;
        }
    }
}
