using AutoMapper;
using MediatR;
using TradeBuddy.Business.Application.DTOs;
using TradeBuddy.Business.Domain.Entities;
using TradeBuddy.Business.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TradeBuddy.Business.Application.Common.mediaterdefine;

namespace TradeBuddy.Business.Application.Queries.Categories
{
    public class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly IRepository<BusinessCategory, Guid> _businessCategoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(IRepository<BusinessCategory, Guid> businessCategoryRepository, IMapper mapper)
        {
            _businessCategoryRepository = businessCategoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            // دریافت تمام دسته‌بندی‌ها از دیتابیس
            var categories = await _businessCategoryRepository.GetAllAsync();

            // تبدیل دسته‌بندی‌ها به CategoryDto با استفاده از AutoMapper
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return categoriesDto;
        }
    }
}
