using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Auth.Domain.Events
{
    public class EditRoleEvent
    {
        public Guid RoleId { get; }
        public string UpdatedBy { get; }
        public DateTime UpdatedAt { get; }

        public EditRoleEvent(Guid roleId, string updatedBy)
        {
            RoleId = roleId;
            UpdatedBy = updatedBy;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
