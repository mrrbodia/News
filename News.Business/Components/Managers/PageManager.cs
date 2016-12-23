using News.Business.IDataProviders;
using News.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Business.Components.Managers
{
    public class PageManager : BaseManager<Page, IPageProvider>
    {
        public PageManager(IPageProvider provider) : base(provider) { }


    }
}
