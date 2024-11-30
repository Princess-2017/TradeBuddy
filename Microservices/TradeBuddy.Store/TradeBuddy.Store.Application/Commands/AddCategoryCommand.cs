using MediatR;

namespace TradeBuddy.Store.Application.Commands
{
    public class AddCategoryCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }

        public AddCategoryCommand(string name, Guid? parentCategoryId = null)
        {
            Name = name;
            ParentCategoryId = parentCategoryId;
        }
    }
}
