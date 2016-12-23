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
    public class NHibernateRoleDataProvider : NHibernateDataProviderBase<Role>, IRoleDataProvider
    {
        public virtual Role GetRoleForName(string name)
        {
            return Execute(session =>
            {
                using (var translation = session.BeginTransaction())
                {
                    return session.CreateCriteria<Role>()
                                  .Add(Restrictions.Eq("Name", name))
                                  .UniqueResult<Role>();
                }
            });
        }
    }
}
