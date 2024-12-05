using MediatR;
using TradeBuddy.Business.Domain.ValueObjects;

namespace TradeBuddy.Business.Application.Commands.Services
{
    public record AddServiceCommand(
     string ServiceName,
     decimal Price,
     string LocationType,
     Guid BusinessId,
     Time StartTime,
     Time EndTime,
     string CreatedBy
 ) : IRequest<Guid>;
}
