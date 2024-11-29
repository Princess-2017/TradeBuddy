using MediatR;
using Nest;
using TradeBuddy.Business.Application.Dto;
using TradeBuddy.Business.Domain.Entities;
using TradeBuddy.Business.Domain.Interfaces;

namespace TradeBuddy.Business.Application.Commands.Elastic
{

    public class SyncBusinessesToElasticCommandHandler : IRequestHandler<SyncBusinessesToElasticCommand, Unit>
    {
        private readonly IElasticClient _elasticClient;
        private readonly IRepository<TradeBuddy.Business.Domain.Entities.Business, Guid> _businessRepository;

        public SyncBusinessesToElasticCommandHandler(
            IElasticClient elasticClient,
            IRepository<TradeBuddy.Business.Domain.Entities.Business, Guid> businessRepository)
        {
            _businessRepository = businessRepository;
            _elasticClient = elasticClient;
        }

        public async Task<Unit> Handle(SyncBusinessesToElasticCommand request, CancellationToken cancellationToken)
        {
            // دریافت اطلاعات کسب‌وکارها از دیتابیس
            var businesses = await _businessRepository.GetAllAsync();

            if (businesses == null || !businesses.Any())
            {
                throw new Exception("No businesses found to sync.");
            }

            // ساخت bulk descriptor برای ارسال داده‌ها به Elasticsearch
            var bulkDescriptor = new BulkDescriptor();
            foreach (var business in businesses)
            {
                bulkDescriptor.Index<BusinessElasticModel>(op => op
                    .Index("business-index")
                    .Id(business.Id.ToString())
                    .Document(new BusinessElasticModel
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
                        Location = $"{business.Latitude},{business.Longitude}", // ارسال موقعیت جغرافیایی
                        BusinessTypeId = business.BusinessTypeId,
                        BusinessCategoryId = business.BusinessCategoryId,
                        IsVerified = business.IsVerified,
                        TotalReviews = business.TotalReviews,
                        AverageRating = business.AverageRating,
                        CreatedAt = business.CreatedAt,
                        UpdatedAt = business.UpdatedAt
                    }));
            }

            // اجرای عملیات bulk
            var bulkResponse = await _elasticClient.BulkAsync(bulkDescriptor, cancellationToken);

            // بررسی خطاهای احتمالی
            if (bulkResponse.Errors)
            {
                var errorMessages = bulkResponse.ItemsWithErrors
                    .Select(e => $"Id: {e.Id}, Error: {e.Error.Reason}")
                    .ToList();
                throw new Exception($"Failed to sync data to Elasticsearch: {string.Join(", ", errorMessages)}");
            }

            return Unit.Value;
        }
    }

}

