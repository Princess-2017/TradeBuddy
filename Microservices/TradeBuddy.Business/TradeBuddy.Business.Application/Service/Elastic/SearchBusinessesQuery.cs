using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Business.Application.Dto;

namespace TradeBuddy.Business.Application.Service.Elastic
{
    public class SearchBusinessesQuery : IRequest<List<BusinessElasticModel>>
    {
        public string Keyword { get; set; }
        public string City { get; set; }
        public bool? IsVerified { get; set; }
    }
}
