using MediatR;

namespace TradeBuddy.Store.Application.Commands
{
    public class AddBrandCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public AddBrandCommand(string name)
        {
            Name = name;
        }
    }
}
