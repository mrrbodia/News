using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News.Business.Models;
using News.Business.IDataProviders;
using NHibernate.Criterion;

namespace News.NHibernateDataProvider.DataProviders
{
    public class NHibernateTidingsDataProvider : NHibernateDataProviderBase<Tidings>, ITidingsDataProvider
    {
        public IList<Tidings> GetForAuthor(string id)
        {
            return Execute(session =>
            {
                return session
                    .CreateCriteria(typeof(Tidings))
                    .Add(Restrictions.Eq("AuthorId", id))
                    .List<Tidings>();
            });
        }
    }
}
