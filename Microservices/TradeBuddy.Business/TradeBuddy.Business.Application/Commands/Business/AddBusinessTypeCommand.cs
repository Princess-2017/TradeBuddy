using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Business.Application.Commands.Business
{
    public class AddBusinessTypeCommand : IRequest<Guid>
    {
        public string Type { get; set; }
    }
}
