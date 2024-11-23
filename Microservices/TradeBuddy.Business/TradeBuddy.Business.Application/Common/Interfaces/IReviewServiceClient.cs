using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Business.Application.Dto;

namespace TradeBuddy.Business.Application.Common.Interfaces
{
    public interface IReviewServiceClient
    {
        Task<List<ReviewDto>> GetReviewsByBusinessIdAsync(Guid businessId);
    }
}
