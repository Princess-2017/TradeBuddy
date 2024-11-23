using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using TradeBuddy.Auth.Domain.Entities;
using TradeBuddy.Auth.Domain.Interfaces;
using TradeBuddy.Auth.Domain.ValueObjects;

namespace TradeBuddy.Auth.Application.Commands.User
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly IRepository<TradeBuddy.Auth.Domain.Entities.User, UserId> _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserCommandHandler(IRepository<TradeBuddy.Auth.Domain.Entities.User, UserId> userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            // Define the search condition using Expression
            Expression<Func<TradeBuddy.Auth.Domain.Entities.User, bool>> predicate = user => user.Username.Value == request.Username;

            // Check if user already exists
            var existingUsers = await _userRepository.SearchAsync(predicate);
            if (existingUsers.Any())
                throw new Exception("User already exists.");

            // Create new user
            var user = new TradeBuddy.Auth.Domain.Entities.User(
                new Domain.ValueObjects.UserId(Guid.NewGuid()),
                new Domain.ValueObjects.Username(request.Username),
                _passwordHasher.HashPassword(request.Password),
                new Domain.ValueObjects.FirstName(request.FirstName),
                new Domain.ValueObjects.LastName(request.LastName),
                new Domain.ValueObjects.Email(request.Email),
                new Domain.ValueObjects.Phone(request.Phone),
                null,
                Domain.Enums.UserType.Customer // یا نوع دیگر
            );

            await _userRepository.AddAsync(user);
            return true;
        }
    }
}
