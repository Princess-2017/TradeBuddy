﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Auth.Domain.Exceptions
{
    public class RoleNotFoundException : Exception
    {
        public RoleNotFoundException(Guid roleId)
            : base($"Role with ID {roleId} not found.")
        {
        }
    }
}