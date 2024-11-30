using MediatR;

namespace TradeBuddy.Pricing.Application.Commands
{
    public class CreateBusinessTypeCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
