using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Store.Domain.Entities;
using TradeBuddy.Store.Domain.Interfaces;

namespace TradeBuddy.Store.Application.Commands
{
    public class AddFeatureValueCommandHandler : IRequestHandler<AddFeatureValueCommand, Guid>
    {
        private readonly IRepository<FeatureValue, Guid> _featureValueRepository;

        public AddFeatureValueCommandHandler(IRepository<FeatureValue, Guid> featureValueRepository)
        {
            _featureValueRepository = featureValueRepository;
        }

        public async Task<Guid> Handle(AddFeatureValueCommand request, CancellationToken cancellationToken)
        {
            var featureValue = new FeatureValue
            {
                Id = Guid.NewGuid(),
                FeatureId = request.FeatureId,
                Value = request.Value
            };

            await _featureValueRepository.AddAsync(featureValue);

            return featureValue.Id;
        }
    }
}
