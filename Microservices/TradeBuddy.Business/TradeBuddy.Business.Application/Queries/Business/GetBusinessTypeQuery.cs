using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Business.Domain.Entities;

namespace TradeBuddy.Business.Application.Queries.Business
{
    public class GetBusinessTypeQuery : IRequest<List<BusinessType>>
    {
    }
}
