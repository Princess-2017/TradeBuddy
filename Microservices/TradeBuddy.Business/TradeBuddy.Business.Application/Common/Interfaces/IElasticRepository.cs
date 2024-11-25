using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Business.Application.Common.Interfaces
{
    public interface IElasticRepository<T>
    {
        Task IndexAsync(T entity);
        Task<List<T>> SearchAsync(string query, Dictionary<string, object> filters);
    }
}
