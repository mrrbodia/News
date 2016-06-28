using FluentNHibernate.Mapping;
using News.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.NHibernateDataProvider.NHibernateCore.Mappings
{
    public class CommentMap : ClassMap<Comment>
    {
        public CommentMap()
        {
            Id(x => x.Id);

            Map(x => x.AuthorId);

            Map(x => x.AuthorName);

            Map(x => x.PostingTime);

            Map(x => x.Text);

            Map(x => x.TidingId);
        }
    }
}
