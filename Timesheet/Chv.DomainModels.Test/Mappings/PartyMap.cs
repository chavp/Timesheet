using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chv.DomainModels.Test.Mappings
{
    using FluentNHibernate.Mapping;

    public class PartyMap
         : ClassMap<Party>
    {
        public PartyMap()
        {
            Id(t => t.Id).GeneratedBy.Identity();
            Map(t => t.Name).Not.Nullable().Unique();

            References(t => t.Parent).LazyLoad();

            HasMany(x => x.Children)
                .LazyLoad()
                .Inverse();

            DiscriminateSubClassesOnColumn("PartyType");
        }
    }
}
