using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using TradeBuddy.Auth.Domain.Entities;
using TradeBuddy.Auth.Domain.Interfaces;
using TradeBuddy.Auth.Domain.ValueObjects;

namespace TradeBuddy.Auth.Application.Commands.User
{
    public class RegisterBusinessOwnerCommandHandler : IRequestHandler<RegisterBusinessOwnerCommand, Guid>
    {
        private readonly IRepository<TradeBuddy.Auth.Domain.Entities.User, UserId> _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterBusinessOwnerCommandHandler(IRepository<TradeBuddy.Auth.Domain.Entities.User, UserId> userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Guid> Handle(RegisterBusinessOwnerCommand request, CancellationToken cancellationToken)
        {
            var userId = new UserId(Guid.NewGuid());
            var businessOwner = new BusinessOwner(
                userId,
                new Username(request.Username),
                _passwordHasher.HashPassword(request.Password),
                new FirstName(request.FirstName),
                new LastName(request.LastName),
                new Email(request.Email),
                new Phone(request.Phone),
                new Address(request.Address), // فرضا آدرس برای ادمین نیاورده‌ایم
                request.BusinessName,
                request.BusinessAddress
            );

            await _userRepository.AddAsync(businessOwner);
            return userId.Value;
        }
    }
}
