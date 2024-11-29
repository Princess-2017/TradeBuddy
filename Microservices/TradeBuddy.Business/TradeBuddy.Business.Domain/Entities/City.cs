using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Business.Domain.Entities
{
    public class City : BaseEntity<Guid>
    {
        public string Name { get; private set; }
        public Guid StateId { get; private set; }
        public virtual State State { get; private set; }

        public City(string name, Guid stateId)
        {
            Id = Guid.NewGuid();
            Name = name;
            StateId = stateId;
        }
    }
}
