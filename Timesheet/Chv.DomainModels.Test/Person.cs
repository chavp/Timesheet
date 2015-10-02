using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chv.DomainModels.Test
{
    public class Person : Party
    {
        protected Person() { }

        public Person(string name):
            base(name) { }

        public virtual Department Department { get; set; }
    }
}
