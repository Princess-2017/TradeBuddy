using MediatR;
using TradeBuddy.Business.Domain.Interfaces;


namespace TradeBuddy.Business.Application.Commands.Services
{
    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, bool>
    {
        private readonly IRepository<TradeBuddy.Business.Domain.Entities.Service, Guid> _serviceRepository;

        public DeleteServiceCommandHandler(IRepository<TradeBuddy.Business.Domain.Entities.Service,Guid> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<bool> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetByIdAsync(request.Id);

            if (service == null)
                return false; // یا می‌توانید یک استثنا پرتاب کنید.

            await _serviceRepository.DeleteAsync(service.Id);
            return true;
        }
    }
}

