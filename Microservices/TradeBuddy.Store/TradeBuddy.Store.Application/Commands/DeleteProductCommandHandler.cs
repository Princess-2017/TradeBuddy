using MediatR;
using TradeBuddy.Store.Domain.Interfaces;

namespace TradeBuddy.Store.Application.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand,Guid>
    {
        private readonly IRepository<Product, Guid> _productRepository;

        public DeleteProductCommandHandler(IRepository<Product, Guid> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Guid> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);

            product.MarkAsDeleted("");
            await _productRepository.UpdateAsync(product);
            return product.Id;
        }
    }
}
