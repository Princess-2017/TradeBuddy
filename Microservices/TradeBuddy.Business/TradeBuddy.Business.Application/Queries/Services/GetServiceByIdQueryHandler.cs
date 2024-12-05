using MediatR;
using TradeBuddy.Business.Application.Dto;
using TradeBuddy.Business.Application.Queries.Services;
using TradeBuddy.Business.Domain.Interfaces;

namespace TradeBuddy.Business.Application.Queries.Services
{

    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, ServiceDto>
    {
        private readonly IRepository<TradeBuddy.Business.Domain.Entities.Service, Guid> _serviceRepository;

        public GetServiceByIdQueryHandler(IRepository<TradeBuddy.Business.Domain.Entities.Service,Guid> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<ServiceDto> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetByIdAsync(request.Id);

            if (service == null)
                return null; // یا می‌توانید استثنا پرتاب کنید

            // تبدیل به DTO
            var serviceDto = new ServiceDto
            {
                Id = service.Id,
                ServiceName = service.ServiceName,
                Price = service.Price,
                StartTime = $"{service.StartHour:D2}:{service.StartMinute:D2}",
                EndTime = $"{service.EndHour:D2}:{service.EndMinute:D2}",
                BusinessId = service.BusinessId
            };

            return serviceDto;
        }
    }
}
