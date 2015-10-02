using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chv.DomainModels.Test
{
    public class Department :
        Organization
    {
        protected Department() { }

        public Department(string name)
            : base(name){ }
    }
}
