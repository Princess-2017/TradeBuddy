using MediatR;
using System;

namespace TradeBuddy.Store.Application.Commands
{
    public class AddProductFeatureCommand : IRequest<Guid>
    {
        public Guid ProductId { get; set; }
        public Guid FeatureId { get; set; }
        public Guid FeatureValueId { get; set; }
    }
}
