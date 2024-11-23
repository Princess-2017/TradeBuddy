using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Business.Application.Dto;

namespace TradeBuddy.Business.Application.Queries.Business
{
    public class GetBusinessQuery : IRequest<BusinessDto>
    {
        public Guid BusinessId { get; set; }
    }
}
