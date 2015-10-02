using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chv.DomainModels.Test.Mappings
{
    using FluentNHibernate.Mapping;

    public class DivisionMap
        : SubclassMap<Division>
    {
        public DivisionMap()
        {
            DiscriminatorValue("Division");
        }
    }
}
