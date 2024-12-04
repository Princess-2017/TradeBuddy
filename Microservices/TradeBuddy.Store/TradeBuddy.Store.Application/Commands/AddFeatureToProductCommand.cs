using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Store.Application.Commands
{
    public class AddFeatureToProductCommand : IRequest<Guid>
    {
        public Guid ProductId { get; set; }
        public Guid FeatureId { get; set; }
        public Guid FeatureValueId { get; set; }
        public Guid StoreId { get; set; }
    }
}
