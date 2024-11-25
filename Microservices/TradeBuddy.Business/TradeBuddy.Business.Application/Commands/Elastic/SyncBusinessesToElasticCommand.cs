using MediatR;

namespace TradeBuddy.Business.Application.Commands.Elastic
{

    // تعریف Command
    public class SyncBusinessesToElasticCommand : IRequest<Unit>
    {
    }
}
