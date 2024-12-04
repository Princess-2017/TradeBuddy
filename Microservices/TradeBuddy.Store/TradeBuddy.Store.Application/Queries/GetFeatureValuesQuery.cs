using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Store.Application.Dto;

namespace TradeBuddy.Store.Application.Queries
{
    public class GetFeatureValuesQuery : IRequest<List<FeatureValueDto>>
    {
        public Guid FeatureId { get; set; }
    }
}
