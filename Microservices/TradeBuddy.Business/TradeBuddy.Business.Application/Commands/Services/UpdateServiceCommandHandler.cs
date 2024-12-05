
using MediatR;
using TradeBuddy.Business.Domain.Entities;
using TradeBuddy.Business.Domain.Interfaces;

namespace TradeBuddy.Business.Application.Commands.Services
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand,Guid>
    {
        private readonly IRepository<TradeBuddy.Business.Domain.Entities.Service, Guid> _serviceRepository;

        public UpdateServiceCommandHandler(IRepository<TradeBuddy.Business.Domain.Entities.Service,Guid> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<Guid> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetByIdAsync(request.Id);
            if (service == null)
            {
                throw new KeyNotFoundException("Service not found");
            }

            service.UpdateService(
                request.ServiceName,
                request.Price,
                null, // مکان‌ها اینجا مدیریت می‌شوند.
                new Domain.ValueObjects.Time(request.StartHour, request.StartMinute),
                new Domain.ValueObjects.Time(request.EndHour, request.EndMinute),
                "Admin");

            await _serviceRepository.UpdateAsync(service);

            return service.Id;
        }
    }

}
