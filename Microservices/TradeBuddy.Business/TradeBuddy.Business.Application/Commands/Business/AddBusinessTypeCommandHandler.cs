using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Business.Domain.Entities;
using TradeBuddy.Business.Domain.Interfaces;

namespace TradeBuddy.Business.Application.Commands.Business
{
    public class AddBusinessTypeCommandHandler : IRequestHandler<AddBusinessTypeCommand, Guid>
    {
        private readonly IRepository<BusinessType, Guid> _repository;

        public AddBusinessTypeCommandHandler(IRepository<BusinessType, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(AddBusinessTypeCommand request, CancellationToken cancellationToken)
        {
            var businessType = new BusinessType(request.Type);

            await _repository.AddAsync(businessType);
            return businessType.Id;
        }
    }
}
