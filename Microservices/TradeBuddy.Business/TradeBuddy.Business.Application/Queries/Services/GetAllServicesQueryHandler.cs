using MediatR;
using Nest;
using TradeBuddy.Business.Application.Dto;
using TradeBuddy.Business.Application.Queries.Services;
using TradeBuddy.Business.Domain.Entities;
using TradeBuddy.Business.Domain.Interfaces;

namespace TradeBuddy.Business.Application.Queries.Services
{

    public class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, List<ServiceDto>>
    {
        private readonly IRepository<TradeBuddy.Business.Domain.Entities.Service, Guid> _serviceRepository;

        public GetAllServicesQueryHandler(IRepository<TradeBuddy.Business.Domain.Entities.Service, Guid> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<List<ServiceDto>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await _serviceRepository.GetAllAsync();
            var serviceDtos = services.Select(service => new ServiceDto
            {
                Id = service.Id,
                ServiceName = service.ServiceName,
                Price = service.Price,
                StartTime = $"{service.StartHour:D2}:{service.StartMinute:D2}",
                EndTime = $"{service.EndHour:D2}:{service.EndMinute:D2}",
                BusinessId = service.BusinessId
            }).ToList();

            return serviceDtos;
        }
    }

}
