using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Business.Domain.Interfaces;

namespace TradeBuddy.Business.Application.Commands.Business
{
    // Handler برای پردازش فرمان بروزرسانی کسب و کار
    public class UpdateBusinessCommandHandler : IRequestHandler<UpdateBusinessCommand, bool>
    {
        private readonly IRepository<TradeBuddy.Business.Domain.Entities.Business, Guid> _businessRepository;

        public UpdateBusinessCommandHandler(IRepository<TradeBuddy.Business.Domain.Entities.Business, Guid> businessRepository)
        {
            _businessRepository = businessRepository;
        }

        public async Task<bool> Handle(UpdateBusinessCommand request, CancellationToken cancellationToken)
        {
            // جستجوی کسب و کار با ID
            var business = await _businessRepository.GetByIdAsync(request.BusinessId);

            // بررسی اینکه کسب و کار پیدا شده یا نه
            if (business == null)
                throw new KeyNotFoundException("کسب و کار پیدا نشد.");

            // بروزرسانی اطلاعات کسب و کار با استفاده از متد UpdateDetails
            business.UpdateDetails(
                request.Name,
                request.Description,
                request.Website,
                request.Email,
                request.Phone,
                request.Address,
                request.City,
                request.State,
                request.PostalCode,
                request.Country,
                request.Latitude,
                request.Longitude,
                request.BusinessTypeId,
                request.BusinessCategoryId
            );

            // ذخیره تغییرات کسب و کار
            await _businessRepository.UpdateAsync(business);

            return true; //  موفقیت به‌روزرسانی شد
        }
    }
}

