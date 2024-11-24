using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Business.Domain.Entities;
using TradeBuddy.Business.Domain.Interfaces;

namespace TradeBuddy.Business.Application.Commands.Business
{
    public class AddBusinessCommandHandler : IRequestHandler<AddBusinessCommand, Guid>
    {
        private readonly IRepository<TradeBuddy.Business.Domain.Entities.Business, Guid> _businessRepository;

        public AddBusinessCommandHandler(IRepository<TradeBuddy.Business.Domain.Entities.Business, Guid> businessRepository)
        {
            _businessRepository = businessRepository;
        }

        public async Task<Guid> Handle(AddBusinessCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ArgumentException("نام کسب و کار نمی‌تواند خالی باشد.");

            var business = new TradeBuddy.Business.Domain.Entities.Business(
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
                                request.BusinessCategoryId,
                                "CreatedBy" // می‌توانید شناسه یا کاربری که این دسته‌بندی را ایجاد می‌کند وارد کنید.
                            );


            await _businessRepository.AddAsync(business);
            
            return business.Id;

        }
    }

}
