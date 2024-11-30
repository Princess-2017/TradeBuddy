using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Store.Domain.Entities;
using TradeBuddy.Store.Domain.Interfaces;
using TradeBuddy.Store.Domain.ValueObjects;

namespace TradeBuddy.Store.Application.Commands
{
    public class AddBrandCommandHandler : IRequestHandler<AddBrandCommand, Guid>
    {
        private readonly IRepository<Brand, Guid> _brandRepository;

        public AddBrandCommandHandler(IRepository<Brand, Guid> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<Guid> Handle(AddBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = new Brand(Guid.NewGuid(), new BrandName(request.Name));
            await _brandRepository.AddAsync(brand);
            return brand.Id;
        }
    }
}
