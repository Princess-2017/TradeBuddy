﻿using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using TradeBuddy.Auth.Domain.Entities;
using TradeBuddy.Auth.Domain.Interfaces;
using TradeBuddy.Auth.Domain.ValueObjects;

namespace TradeBuddy.Auth.Application.Commands.User
{
    public class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand, Guid>
    {
        private readonly IRepository<TradeBuddy.Auth.Domain.Entities.User, UserId> _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterCustomerCommandHandler(IRepository<TradeBuddy.Auth.Domain.Entities.User, UserId> userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Guid> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {
            var userId = new UserId(Guid.NewGuid());
            var customer = new Customer(
                userId,
                new Username(request.Username),
                _passwordHasher.HashPassword(request.Password),
                new FirstName(request.FirstName),
                new LastName(request.LastName),
                new Email(request.Email),
                new Phone(request.Phone),
                new Address(request.Address),
                request.ShippingAddress
            );

            await _userRepository.AddAsync(customer);
            return userId.Value;
        }
    }
}