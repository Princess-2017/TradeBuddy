using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Business.Application.Dto;
using TradeBuddy.Business.Domain.Entities;
using TradeBuddy.Business.Domain.Interfaces;

namespace TradeBuddy.Business.Application.Queries.Business
{
    public class GetAllBusinessesQueryHandler : IRequestHandler<GetAllBusinessesQuery, PaginatedResult<BusinessDto>>
    {
        private readonly IRepository<TradeBuddy.Business.Domain.Entities.Business, Guid> _businessRepository;
        private readonly IMapper _mapper;

        public GetAllBusinessesQueryHandler(IRepository<TradeBuddy.Business.Domain.Entities.Business, Guid> businessRepository, IMapper mapper)
        {
            _businessRepository = businessRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<BusinessDto>> Handle(GetAllBusinessesQuery request, CancellationToken cancellationToken)
        {
            // گرفتن کل داده‌ها از دیتابیس
            var totalCount = await _businessRepository.CountAsync(); // تعداد کل آیتم‌ها
            var businesses = await _businessRepository.GetPagedAsync(request.PageNumber, request.PageSize);

            // تبدیل به DTO
            var businessDtos = _mapper.Map<IEnumerable<BusinessDto>>(businesses);

            // ساخت نتیجه پایگینیشن
            var result = new PaginatedResult<BusinessDto>(
                businessDtos,
                totalCount,
                request.PageNumber,
                request.PageSize
            );

            return result;
        }
    }
}
