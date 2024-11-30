using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Pricing.Domain.Entities;
using TradeBuddy.Pricing.Domain.Interfaces;

namespace TradeBuddy.Pricing.Application.Commands
{
    public class CreateIndustryCategoryHandler : IRequestHandler<CreateIndustryCategoryCommand, int>
    {
        private readonly IRepository<IndustryCategory, int> _repository;

        public CreateIndustryCategoryHandler(IRepository<IndustryCategory, int> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateIndustryCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = new IndustryCategory
            {
                Name = request.Dto.Name,
                Description = request.Dto.Description,
                IsActive = request.Dto.IsActive,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(entity);
            return entity.Id;
        }
    }
}
