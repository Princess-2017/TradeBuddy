using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Business.Application.Dto;
using TradeBuddy.Business.Application.DTOs;
using TradeBuddy.Business.Domain.Entities;

namespace TradeBuddy.Business.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BusinessCategory, CategoryDto>();
            CreateMap<TradeBuddy.Business.Domain.Entities.Business, BusinessDto>();
        }
    }
}
