using FluentNHibernate.Mapping;
using News.Business.Models;

namespace News.NHibernateDataProvider.NHibernateCore.Mappings
{
    public class TidingsMap : ClassMap<Tidings>
    {
        public TidingsMap()
        {
            Id(x => x.Id);

            Map(x => x.Title);

            Map(x => x.Discription);

            Map(x => x.AuthorId);

            Map(x => x.PublishData);
        }
    }
}
