using AAYW.Core.Models.Mappings;
using FluentNHibernate.Mapping;
using News.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAYW.Core.Models.Mappings
{
    class PageMap : ClassMap<Page>
    {
        public PageMap()
        {
            Id(x => x.Id);

            Map(x => x.ContentBlocks).CustomSqlType("xml");

            Map(x => x.Title).Length(300);

            Map(x => x.Url).Length(100);
        }
    }
}
