using MediatR;

namespace TradeBuddy.Business.Application.Commands.Categories
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public Guid CategoryId { get; set; }

        public DeleteCategoryCommand() { } // سازنده بدون پارامتر

        public DeleteCategoryCommand(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
