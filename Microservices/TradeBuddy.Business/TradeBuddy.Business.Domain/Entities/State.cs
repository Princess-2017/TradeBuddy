using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Business.Domain.Entities
{
    public class State : BaseEntity<Guid>
    {
        public string Name { get; private set; }

        public State(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
