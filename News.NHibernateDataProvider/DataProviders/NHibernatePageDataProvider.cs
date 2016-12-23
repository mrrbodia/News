using News.Business.IDataProviders;
using News.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.NHibernateDataProvider.DataProviders
{
    public class NHibernatePageDataProvider : NHibernateDataProviderBase<Page>, IPageProvider
    {
    }
}
