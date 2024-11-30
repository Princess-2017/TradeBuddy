using MediatR;
using TradeBuddy.Pricing.Domain.Entities;
using TradeBuddy.Pricing.Domain.Interfaces;

namespace TradeBuddy.Pricing.Application.Queries
{
    public class GetBusinessTypesQueryHandler : IRequestHandler<GetBusinessTypesQuery, IEnumerable<BusinessType>>
    {
        private readonly IRepository<BusinessType, int> _repository;

        public GetBusinessTypesQueryHandler(IRepository<BusinessType, int> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BusinessType>> Handle(GetBusinessTypesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
