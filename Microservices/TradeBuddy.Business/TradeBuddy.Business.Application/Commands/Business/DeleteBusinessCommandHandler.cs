using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Business.Application.Commands.Categories;
using TradeBuddy.Business.Domain.Interfaces;

namespace TradeBuddy.Business.Application.Commands.Business
{
    public class DeleteBusinessCommandHandler : IRequestHandler<DeleteBusinessCommand, bool>
    {
        private readonly IRepository<TradeBuddy.Business.Domain.Entities.Business, Guid> _businessRepository;

        public DeleteBusinessCommandHandler(IRepository<TradeBuddy.Business.Domain.Entities.Business, Guid> businessRepository)
        {
            _businessRepository = businessRepository;
        }

        public async Task<bool> Handle(DeleteBusinessCommand request, CancellationToken cancellationToken)
        {
            var business = await _businessRepository.GetByIdAsync(request.BusinessId);

            if (business == null)
                throw new KeyNotFoundException("کسب و کار پیدا نشد.");

            await _businessRepository.DeleteAsync(request.BusinessId);

            return true;
        }
    }
}
