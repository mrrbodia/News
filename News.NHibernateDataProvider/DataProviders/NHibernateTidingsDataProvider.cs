using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News.Business.Models;
using News.Business.IDataProviders;

namespace News.NHibernateDataProvider.DataProviders
{
    public class NHibernateTidingsDataProvider : NHibernateDataProviderBase<Tidings>, ITidingsDataProvider
    {

    }
}
