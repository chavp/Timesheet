using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chv.DomainModels.Test
{
    public class Division :
        Organization
    {
         protected Division() { }

         public Division(string name)
            : base(name){ }
    }
}
