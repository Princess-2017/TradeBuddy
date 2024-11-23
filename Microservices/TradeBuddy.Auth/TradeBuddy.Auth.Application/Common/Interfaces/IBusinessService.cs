using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Business.Application.Common.Interfaces
{
    public interface IBusinessService
    {
        /// <summary>
        /// متدی برای پردازش پیام و پاسخ به آن.
        /// </summary>
        /// <param name="message">پیام ورودی</param>
        /// <returns>پاسخ به پیام</returns>
        Task<string> ProcessMessageAsync(string message);
    }
}
