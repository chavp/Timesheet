using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chv.DomainModels.Test
{
    public abstract class Party
    {
        protected Party() { }

        public Party(string name)
        {
            Name = name;
            Children = new List<Party>();
        }

        public virtual long Id { get; protected set; }
        public virtual string Name { get; set; }

        public virtual Party Parent { get; set; }
        public virtual IList<Party> Children { get; protected set; }
    }
}
