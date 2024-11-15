using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Auth.Domain.ValueObjects;

namespace TradeBuddy.Auth.Domain.Entities
{
    public class Permission : BaseEntity<PermissionId>
    {
        public string Name { get; private set; }
        public string CreatedBy { get; private set; }

        // سازنده بدون پارامتر برای EF Core
        private Permission() { }

        public void Initialize(string name, string createdBy)
        {
            Name = name;
            CreatedBy = createdBy;
        }
    }

}
