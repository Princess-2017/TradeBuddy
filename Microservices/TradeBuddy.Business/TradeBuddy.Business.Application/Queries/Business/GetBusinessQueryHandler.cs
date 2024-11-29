using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Business.Application.Common.Interfaces;
using TradeBuddy.Business.Application.Dto;
using TradeBuddy.Business.Domain.Entities;
using TradeBuddy.Business.Domain.Interfaces;

namespace TradeBuddy.Business.Application.Queries.Business
{
    public class GetBusinessQueryHandler : IRequestHandler<GetBusinessQuery, BusinessDto>
    {
        private readonly IRepository<TradeBuddy.Business.Domain.Entities.Business, Guid> _businessRepository;
        private readonly IReviewServiceClient _reviewServiceClient;

        public GetBusinessQueryHandler(IRepository<TradeBuddy.Business.Domain.Entities.Business, Guid> businessRepository, IReviewServiceClient reviewServiceClient)
        {
            _businessRepository = businessRepository;
            _reviewServiceClient = reviewServiceClient;
        }

        public async Task<BusinessDto> Handle(GetBusinessQuery request, CancellationToken cancellationToken)
        {
            var business = await _businessRepository.GetByIdAsync(request.BusinessId);

            if (business == null)
                throw new KeyNotFoundException("کسب و کار پیدا نشد.");

            // دریافت اطلاعات نظرات کسب و کار از میکروسرویس نظرات
            var reviewSummary = await _reviewServiceClient.GetReviewsByBusinessIdAsync(business.Id);

            return new BusinessDto
            {
                Id = business.Id,
                Name = business.Name,
                Description = business.Description,
                Website = business.Website,
                Email = business.Email,
                Phone = business.Phone,
                Address = business.Address,
                City = business.CityId,
                State = business.StateId,
                PostalCode = business.PostalCode,
                Country = business.Country,
                Latitude = business.Latitude,
                Longitude = business.Longitude,
                BusinessTypeId = business.BusinessTypeId,
                BusinessCategoryId = business.BusinessCategoryId,
                TotalReviews = reviewSummary.Count(),
                AverageRating = reviewSummary.Average(r => r.Rating)
            };
        }
    }
}
