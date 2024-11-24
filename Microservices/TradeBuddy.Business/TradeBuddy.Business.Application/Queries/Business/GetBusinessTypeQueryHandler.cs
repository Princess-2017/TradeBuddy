using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TradeBuddy.Business.Domain.Entities;
using TradeBuddy.Business.Domain.Interfaces;

namespace TradeBuddy.Business.Application.Queries.Business
{
    public class GetBusinessTypeQueryHandler : IRequestHandler<GetBusinessTypeQuery, List<BusinessType>>
    {
        private readonly IRepository<BusinessType, Guid> _repository;

        public GetBusinessTypeQueryHandler(IRepository<BusinessType, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<List<BusinessType>> Handle(GetBusinessTypeQuery request, CancellationToken cancellationToken)
        {
            var businessTypes = await _repository.GetAllAsync();

            if (businessTypes == null || !businessTypes.Any())
                throw new KeyNotFoundException("BusinessType not found");

            return businessTypes.ToList();
        }
    }
}
