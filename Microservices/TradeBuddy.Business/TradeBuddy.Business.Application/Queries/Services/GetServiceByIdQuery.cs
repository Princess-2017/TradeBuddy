using MediatR;
using System;
using TradeBuddy.Business.Application.Dto;

namespace TradeBuddy.Business.Application.Queries.Services
{

    public class GetServiceByIdQuery : IRequest<ServiceDto>
    {
        public Guid Id { get; }

        public GetServiceByIdQuery(Guid id)
        {
            Id = id;
        }
    }

}
