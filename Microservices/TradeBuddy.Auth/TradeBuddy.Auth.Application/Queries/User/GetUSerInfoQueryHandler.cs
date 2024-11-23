using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using TradeBuddy.Auth.Application.Commands.User;
using TradeBuddy.Auth.Application.Dto;
using TradeBuddy.Auth.Domain.Entities;
using TradeBuddy.Auth.Domain.Interfaces;
using TradeBuddy.Auth.Domain.ValueObjects;
using TradeBuddy.Business.Application.Queries.User;
using TradeBuddy.Review.Application.Exceptions;


namespace TradeBuddy.Auth.Application.Queries.User
{
    public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, UserProfileDto>
    {
        private readonly IRepository<Domain.Entities.User, UserId> _userRepository;
        public GetUserInfoQueryHandler(IRepository<Domain.Entities.User, UserId> userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<UserProfileDto> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var userId = new UserId(request.UserId);

            // دریافت اطلاعات کاربر از پایگاه داده
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                // اگر کاربر پیدا نشد، مقدار null باز می‌گردد یا خطا ارسال می‌شود
                return null; // یا می‌توانید یک exception مثل NotFoundException پرتاب کنید
            }

            // تبدیل اطلاعات کاربر به UserProfileDto
            var userProfileDto = new UserProfileDto
            {
                Username = user.Username,
                Email = user.Email,
                PhoneNumber = user.Phone,
                FullName = $"{user.FirstName} {user.LastName}",
                RegisteredAt = user.CreateDate.ToPersianDateString(), // تبدیل به تاریخ شمسی
                Address = user.Address
            };

            return userProfileDto;
        }
    }
}
