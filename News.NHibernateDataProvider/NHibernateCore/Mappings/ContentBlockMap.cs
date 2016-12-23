using FluentNHibernate.Mapping;
using News.Business.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.NHibernateDataProvider.NHibernateCore.Mappings
{
    public class ContentBlockMap : ClassMap<ContentBlock>
    {
        public ContentBlockMap()
        {
            Id(x => x.Id);

            Map(x => x.Name).Length(100);

            Map(x => x.Type);

            Map(x => x.Content).CustomSqlType("text");
        }
    }
}
