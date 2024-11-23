using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Business.Application.Commands.Business
{
    public class DeleteBusinessCommand : IRequest<bool>
    {
        public Guid BusinessId { get; set; }
    }
}
