using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using TradeBuddy.Auth.Application.Commands.User;
using TradeBuddy.Auth.Domain.Entities;
using TradeBuddy.Auth.Domain.Interfaces;
using TradeBuddy.Auth.Domain.ValueObjects;

public class RegisterAdminCommandHandler : IRequestHandler<RegisterAdminCommand, Guid>
{
    private readonly IRepository<TradeBuddy.Auth.Domain.Entities.User, UserId> _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterAdminCommandHandler(IRepository<TradeBuddy.Auth.Domain.Entities.User, UserId> userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Guid> Handle(RegisterAdminCommand request, CancellationToken cancellationToken)
    {
        // ایجاد مقادیر مورد نیاز برای ثبت‌نام
        var userId = new UserId(Guid.NewGuid()); // شناسنامه جدید برای کاربر
        var usernameObj = new Username(request.Username); // ایجاد شیء نام کاربری
        var passwordHash = _passwordHasher.HashPassword(request.Password); // هش کردن پسورد
        var firstNameObj = new FirstName(request.FirstName);
        var lastNameObj = new LastName(request.LastName);
        var emailObj = new Email(request.Email);
        var phoneObj = new Phone(request.Phone);
        var addressObj = new Address("N/A"); // فرضا آدرس برای ادمین نیاورده‌ایم

        // ساخت ادمین جدید
        var admin = new Admin(userId, usernameObj, passwordHash, firstNameObj, lastNameObj, emailObj, phoneObj, addressObj);

        // ذخیره ادمین در دیتابیس
        await _userRepository.AddAsync(admin); // فرض بر اینکه AddAsync استفاده می‌کنیم

        return userId.Value;
    }
}
