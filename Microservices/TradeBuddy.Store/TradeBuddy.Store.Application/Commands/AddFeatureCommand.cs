using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Store.Application.Commands
{
    public class AddFeatureCommand : IRequest<Guid>
    {
        public Guid StoreId { get; set; }
        public string Name { get; set; }
        public List<Guid> DependencyIds { get; set; } = new List<Guid>();
    }
}
