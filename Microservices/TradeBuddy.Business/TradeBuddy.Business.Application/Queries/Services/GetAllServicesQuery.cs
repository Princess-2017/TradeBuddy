using MediatR;
using System.Collections.Generic;
using TradeBuddy.Business.Application.Dto;

namespace TradeBuddy.Business.Application.Queries.Services
{

    public class GetAllServicesQuery : IRequest<List<ServiceDto>> { }

}
