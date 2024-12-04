using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Auth.Application.Commands.Permission
{
    public class AddPermissionCommand : IRequest<Guid>
    {
        public string Name { get; private set; }
        public string ObjectType { get; private set; } // نوع شیء (مثلاً منو، دکمه)
        public string ObjectKey { get; private set; } // کلید یکتا برای شیء (مثلاً ID منو یا دکمه)
        public string Action { get; private set; } // عمل مجاز (مثلاً "Read", "Write", "Delete")

        public AddPermissionCommand(string name, string objecttype, string objectkey,string action)
        {
            Name = name;
            ObjectType = objecttype;
            ObjectKey = objectkey;
            Action = action;
        }
    }
}
