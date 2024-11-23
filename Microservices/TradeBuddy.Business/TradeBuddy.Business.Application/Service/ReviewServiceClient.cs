using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TradeBuddy.Business.Application.Common.Interfaces;
using TradeBuddy.Business.Application.Dto;

namespace TradeBuddy.Business.Application.Service
{
    public class ReviewServiceClient : IReviewServiceClient
    {
        private readonly HttpClient _httpClient;

        public ReviewServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ReviewDto>> GetReviewsByBusinessIdAsync(Guid businessId)
        {
            try
            {
                var url = $"/api/reviews/business/{businessId}";
                var reviews = await _httpClient.GetFromJsonAsync<List<ReviewDto>>(url);

                return reviews ?? new List<ReviewDto>();
            }
            catch (HttpRequestException ex)
            {
                // Log error
                throw new Exception($"Failed to fetch reviews for business {businessId}", ex);
            }
        }
    }
}
