﻿using System;
using System.Collections.Generic;
using TradeBuddy.Auth.Domain.Enums;
using TradeBuddy.Auth.Domain.ValueObjects;

namespace TradeBuddy.Auth.Domain.Entities
{
    public class User : BaseEntity<UserId>
    {
        public virtual UserId Id { get; private set; }
        public virtual Username Username { get; private set; }
        public string PasswordHash { get; private set; }
        public virtual FirstName FirstName { get; private set; }
        public virtual LastName LastName { get; private set; }
        public virtual Email Email { get; private set; }
        public virtual Phone Phone { get; private set; }
        public virtual Address Address { get; private set; }
        public bool IsActive { get; private set; }
        public UserType UserType { get; private set; } // نوع کاربر

        private readonly HashSet<RoleId> _roles = new();
        private readonly HashSet<PermissionId> _permissions = new();

        // سازنده بدون پارامتر برای EF Core
        protected User() { }

        public User(UserId id, Username username, string passwordHash, FirstName firstName, LastName lastName, Email email, Phone phone, Address address, UserType userType)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Username = username ?? throw new ArgumentNullException(nameof(username));
            PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            IsActive = true;
            UserType = userType; // مقداردهی نوع کاربر
        }

        // متدهای مدیریت نقش‌ها و مجوزها
        public void AssignRole(RoleId roleId) => _roles.Add(roleId ?? throw new ArgumentNullException(nameof(roleId)));
        public void RemoveRole(RoleId roleId) => _roles.Remove(roleId ?? throw new ArgumentNullException(nameof(roleId)));
        public IEnumerable<RoleId> GetRoles() => _roles;

        public void AddPermission(PermissionId permissionId) => _permissions.Add(permissionId ?? throw new ArgumentNullException(nameof(permissionId)));
        public void RemovePermission(PermissionId permissionId) => _permissions.Remove(permissionId ?? throw new ArgumentNullException(nameof(permissionId)));
        public IEnumerable<PermissionId> GetPermissions() => _permissions;
    }

    public class BusinessOwner : User
    {
        public string BusinessName { get; private set; }
        public string BusinessAddress { get; private set; }

        public BusinessOwner(UserId id, Username username, string passwordHash, FirstName firstName, LastName lastName, Email email, Phone phone, Address address, string businessName, string businessAddress)
            : base(id, username, passwordHash, firstName, lastName, email, phone, address, UserType.BusinessOwner)
        {
            BusinessName = businessName ?? throw new ArgumentNullException(nameof(businessName));
            BusinessAddress = businessAddress ?? throw new ArgumentNullException(nameof(businessAddress));
        }
    }

    public class Customer : User
    {
        public string ShippingAddress { get; private set; }

        public Customer(UserId id, Username username, string passwordHash, FirstName firstName, LastName lastName, Email email, Phone phone, Address address, string shippingAddress)
            : base(id, username, passwordHash, firstName, lastName, email, phone, address, UserType.Customer)
        {
            ShippingAddress = shippingAddress ?? throw new ArgumentNullException(nameof(shippingAddress));
        }
    }
}