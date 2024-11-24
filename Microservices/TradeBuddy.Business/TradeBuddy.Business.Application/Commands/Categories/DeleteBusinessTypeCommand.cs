using MediatR;

namespace TradeBuddy.Business.Application.Commands.Categories
{
    public class DeleteBusinessTypeCommand : IRequest<bool>
    {
        public Guid BusinessTypeId { get; set; }
    }
}
