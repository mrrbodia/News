using FluentNHibernate.Mapping;
using News.Business.Models;

namespace News.NHibernateDataProvider.NHibernateCore.Mappings
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);
        }
    }
}
