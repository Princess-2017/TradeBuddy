using MediatR;

namespace TradeBuddy.Business.Application.Commands.Categories
{
    public class AddCategoryCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public AddCategoryCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
