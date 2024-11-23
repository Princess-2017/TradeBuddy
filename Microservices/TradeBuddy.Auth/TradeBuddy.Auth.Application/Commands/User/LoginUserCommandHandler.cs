using MediatR;
using Microsoft.AspNetCore.Identity;
using TradeBuddy.Auth.Domain.Interfaces;
using TradeBuddy.Auth.Domain.Entities;
using System;
using TradeBuddy.Auth.Application.Common.Interfaces;
using TradeBuddy.Auth.Domain.ValueObjects;

namespace TradeBuddy.Auth.Application.Commands.User
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IRepository<TradeBuddy.Auth.Domain.Entities.User, UserId> _userRepository;
        private readonly IPasswordHasher<TradeBuddy.Auth.Domain.Entities.User> _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginUserCommandHandler(
            IRepository<TradeBuddy.Auth.Domain.Entities.User, UserId> userRepository,
            IPasswordHasher<TradeBuddy.Auth.Domain.Entities.User> passwordHasher,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // Fetch user by username
            var user = await _userRepository.SearchAsync(u => u.Username.Value == request.Username);

            if (user == null || user.Count == 0)
                throw new Exception("Invalid username or password.");

            var existingUser = user.First();

            // Verify password
            var verificationResult = _passwordHasher.VerifyHashedPassword(existingUser, existingUser.PasswordHash, request.Password);
            if (verificationResult != PasswordVerificationResult.Success)
                throw new Exception("Invalid username or password.");

            // Generate JWT token
            var token = _jwtTokenGenerator.GenerateToken(existingUser);

            return token;
        }
    }
}
