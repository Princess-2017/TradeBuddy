using System;
using System.Collections.Generic;
using TradeBuddy.Auth.Domain.ValueObjects;

namespace TradeBuddy.Auth.Domain.Entities
{
    public class Role : BaseEntity<Guid>
    {
        public string Name { get; private set; }
        public virtual List<Permission> Permissions { get; private set; } = new();

        // سازنده بدون پارامتر برای EF Core
        private Role() { }

        public Role(Guid id,string name)
        {
            Id = id;
            Name = name;
        }

        public void AddPermission(Permission permission)
        {
            if (!Permissions.Contains(permission))
            {
                Permissions.Add(permission);
            }
        }

        public void RemovePermission(Permission permission)
        {
            Permissions.Remove(permission);
        }
    }
}
