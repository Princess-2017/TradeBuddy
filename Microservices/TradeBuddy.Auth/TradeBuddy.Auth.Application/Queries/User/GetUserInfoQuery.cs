using MediatR;
using TradeBuddy.Auth.Application.Dto;

namespace TradeBuddy.Business.Application.Queries.User
{
    /// <summary>
    /// کوئری برای دریافت اطلاعات پروفایل کاربر
    /// </summary>
    public class GetUserInfoQuery : IRequest<UserProfileDto>
    {
        /// <summary>
        /// شناسه کاربر
        /// </summary>
        public Guid UserId { get; set; }
        public GetUserInfoQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
