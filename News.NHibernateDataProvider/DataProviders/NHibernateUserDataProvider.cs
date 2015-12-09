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
    public class NHibernateUserDataProvider : NHibernateDataProviderBase<User>, IUserDataProvider
    {
        public User GetByEmail(string email)
        {
            return Execute(session =>
            {
                return session
                    .CreateCriteria<User>()
                    .Add(Restrictions.Eq("Email", email))
                    .UniqueResult<User>();
            });
        }
    }
}
