using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TradeBuddy.Business.Domain.Interfaces;

namespace TradeBuddy.Business.Application.Commands.Categories
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly IRepository<Domain.Entities.BusinessCategory, Guid> _businessCategoryRepository;

        public DeleteCategoryCommandHandler(IRepository<Domain.Entities.BusinessCategory, Guid> businessCategoryRepository)
        {
            _businessCategoryRepository = businessCategoryRepository;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _businessCategoryRepository.GetByIdAsync(request.CategoryId);
            if (category == null)
            {
                return false; // دسته‌بندی پیدا نشد
            }

            await _businessCategoryRepository.DeleteAsync(request.CategoryId);
            return true; // دسته‌بندی با موفقیت حذف شد
        }
    }
}
