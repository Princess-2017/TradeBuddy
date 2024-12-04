using MediatR;

namespace TradeBuddy.Store.Application.Commands
{
    public class AddFeatureValueCommand : IRequest<Guid>
    {
        public Guid FeatureId { get; set; }
        public string Value { get; set; }
    }
}
