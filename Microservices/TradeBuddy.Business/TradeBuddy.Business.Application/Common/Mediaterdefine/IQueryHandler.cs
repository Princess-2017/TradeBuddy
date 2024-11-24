using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Business.Application.Common.mediaterdefine
{
    // Interface برای کوئری‌ها
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }

    // Interface برای هندلرهای کوئری
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
    {
    }
}
