using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Auth.Domain.ValueObjects;

namespace TradeBuddy.Auth.Domain.Entities;
public class Permission : BaseEntity<Guid>
{
    public string Name { get; private set; }
    public string ObjectType { get; private set; } // نوع شیء (مثلاً منو، دکمه)
    public string ObjectKey { get; private set; } // کلید یکتا برای شیء (مثلاً ID منو یا دکمه)
    public string Action { get; private set; } // عمل مجاز (مثلاً "Read", "Write", "Delete")

    private Permission() { }

    public Permission(Guid id,string name, string objectType, string objectKey, string action)
    {
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        ObjectType = objectType ?? throw new ArgumentNullException(nameof(objectType));
        ObjectKey = objectKey ?? throw new ArgumentNullException(nameof(objectKey));
        Action = action ?? throw new ArgumentNullException(nameof(action));
    }
}
