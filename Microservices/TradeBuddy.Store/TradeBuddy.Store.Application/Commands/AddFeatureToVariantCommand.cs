using MediatR;
namespace TradeBuddy.Store.Application.Commands
{
    public class AddFeatureToVariantCommand : IRequest<Guid>
    {
        public Guid VariantId { get; set; }
        public Guid FeatureId { get; set; }
        public Guid FeatureValueId { get; set; }
        public Guid StoreId { get; set; }
    }

}
