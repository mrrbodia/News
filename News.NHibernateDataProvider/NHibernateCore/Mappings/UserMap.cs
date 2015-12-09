using FluentNHibernate.Mapping;
using News.Business.Models;

namespace News.NHibernateDataProvider.NHibernateCore.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);

            Map(x => x.Email);

            Map(x => x.Password);

            Map(x => x.PasswordSalt);

            References(x => x.Role).Class<Role>().Not.LazyLoad();
        }
    }
}
