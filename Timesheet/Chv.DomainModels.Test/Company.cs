using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chv.DomainModels.Test
{
    public class Company :
        Organization
    {
        protected Company() { }

        public Company(string name)
            : base(name){ }


    }
}
