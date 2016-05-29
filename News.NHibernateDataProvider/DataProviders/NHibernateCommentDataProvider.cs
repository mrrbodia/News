using News.Business.IDataProviders;
using News.Business.Models;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.NHibernateDataProvider.DataProviders
{
    public class NHibernateCommentDataProvider : NHibernateDataProviderBase<Comment>, ICommentDataProvider
    {
        public IList<Comment> GetByTidingId(string id)
        {
            return Execute(session =>
            {
                var criteria = session.CreateCriteria<Comment>();
                criteria.Add(Expression.Eq("TidingId", id));
                return criteria.List<Comment>();
            });
        }
    }
}
