using MediatR;

namespace TradeBuddy.Business.Application.Commands.Services
{
    public class DeleteServiceCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteServiceCommand(Guid id)
        {
            Id = id;
        }
    }
}
