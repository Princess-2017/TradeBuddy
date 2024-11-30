using MediatR;
using TradeBuddy.Store.Domain.Entities;
using TradeBuddy.Store.Domain.Interfaces;

namespace TradeBuddy.Store.Application.Commands
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Guid>
    {
        private readonly IRepository<Category, Guid> _categoryRepository;

        public AddCategoryCommandHandler(IRepository<Category, Guid> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Guid> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(Guid.NewGuid(), new Domain.ValueObjects.CategoryName(request.Name), request.ParentCategoryId);
            await _categoryRepository.AddAsync(category);
            return category.Id;
        }
    }
}
