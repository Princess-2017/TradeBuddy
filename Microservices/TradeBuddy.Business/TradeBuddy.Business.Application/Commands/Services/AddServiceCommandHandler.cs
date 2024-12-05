using MediatR;
using TradeBuddy.Business.Domain.Entities;
using TradeBuddy.Business.Domain.Interfaces;
using TradeBuddy.Business.Domain.ValueObjects;

namespace TradeBuddy.Business.Application.Commands.Services
{
    public class CreateServiceCommandHandler : IRequestHandler<AddServiceCommand, Guid>
    {
        private readonly IRepository<Domain.Entities.Service, Guid> _serviceRepository;

        public CreateServiceCommandHandler(IRepository<Domain.Entities.Service, Guid> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<Guid> Handle(AddServiceCommand request, CancellationToken cancellationToken)
        {
            var service = new Domain.Entities.Service(
                request.ServiceName,
                request.Price,
                new ServiceLocationType(request.LocationType), // مثال ساده
                request.CreatedBy,
                request.StartTime,
                request.EndTime,
                request.BusinessId
            );

            await _serviceRepository.AddAsync(service);
            return service.Id;
        }
    }
}
