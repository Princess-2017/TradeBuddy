using MediatR;
using System;

namespace TradeBuddy.Store.Application.Commands
{
    public class AddProductVariantFeatureCommand : IRequest<Guid>
    {
        public Guid ProductVariantId { get; set; }
        public Guid FeatureId { get; set; }
        public Guid FeatureValueId { get; set; }
    }
}
