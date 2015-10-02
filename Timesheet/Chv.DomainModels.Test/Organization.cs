using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chv.DomainModels.Test
{
    public abstract class Organization : Party
    {
        protected Organization() { }

        public Organization(string name) :
            base(name)
        {

        }
    }
}
