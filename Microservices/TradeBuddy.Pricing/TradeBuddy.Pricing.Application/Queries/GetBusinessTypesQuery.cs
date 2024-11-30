using MediatR;
using TradeBuddy.Pricing.Domain.Entities;

namespace TradeBuddy.Pricing.Application.Queries
{
    public class GetBusinessTypesQuery : IRequest<IEnumerable<BusinessType>>
    {
    }
}
