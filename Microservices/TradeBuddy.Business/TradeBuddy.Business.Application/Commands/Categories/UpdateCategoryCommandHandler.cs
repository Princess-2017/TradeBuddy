using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TradeBuddy.Business.Domain.Interfaces;

namespace TradeBuddy.Business.Application.Commands.Categories
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly IRepository<Domain.Entities.BusinessCategory, Guid> _businessCategoryRepository;

        public UpdateCategoryCommandHandler(IRepository<Domain.Entities.BusinessCategory, Guid> businessCategoryRepository)
        {
            _businessCategoryRepository = businessCategoryRepository;
        }

        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _businessCategoryRepository.GetByIdAsync(request.CategoryId);
            if (category == null)
            {
                return false; // دسته‌بندی پیدا نشد
            }

            // به‌روزرسانی دسته‌بندی با استفاده از متد UpdateCategory
            category.UpdateCategory(request.Name, request.Description);

            await _businessCategoryRepository.UpdateAsync(category);
            return true; // دسته‌بندی با موفقیت به‌روزرسانی شد
        }
    }
}
