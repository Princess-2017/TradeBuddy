using MediatR;

namespace TradeBuddy.Order.Application.Commands
{

    public class UpdateOrderCommand : IRequest<Guid>
    {
        public Guid OrderId { get; set; }
        public string Status { get; set; }
    }

}
