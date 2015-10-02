using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chv.DomainModels.Test.Mappings
{
    using FluentNHibernate.Mapping;

    public class PersonMap
        : SubclassMap<Person>
    {
        public PersonMap()
        {
            DiscriminatorValue("Person");

            References(t => t.Department).LazyLoad();
        }
    }
}
