using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Pricing.Application.Dto;

namespace TradeBuddy.Pricing.Application.Commands
{
    public record CreateIndustryCategoryCommand(IndustryCategoryCreateDto Dto) : IRequest<int>;
}
