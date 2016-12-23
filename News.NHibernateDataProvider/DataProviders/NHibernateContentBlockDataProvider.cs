using News.Business.IDataProviders;
using News.Business.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.NHibernateDataProvider.DataProviders
{
    public class NHibernateContentBlockDataProvider : NHibernateDataProviderBase<ContentBlock>, IContentBlockProvider
    {
    }
}
