using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Business.Domain.Entities;
using TradeBuddy.Business.Domain.Interfaces;

namespace TradeBuddy.Business.Application.Commands.Categories
{
    public class DeleteBusinessTypeCommandHandler : IRequestHandler<DeleteBusinessTypeCommand, bool>
    {
        private readonly IRepository<BusinessType, Guid> _repository;

        public DeleteBusinessTypeCommandHandler(IRepository<BusinessType, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteBusinessTypeCommand request, CancellationToken cancellationToken)
        {
            var businessType = await _repository.GetByIdAsync(request.BusinessTypeId);

            if (businessType == null)
                throw new KeyNotFoundException("BusinessType not found");

            await _repository.DeleteAsync(businessType.Id);
            return true;
        }
    }
}
