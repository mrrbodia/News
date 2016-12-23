using News.Business.IDataProviders;
using News.Business.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Business.Components.Managers
{
    public class ContentBlockManager : BaseManager<ContentBlock, IContentBlockProvider>
    {
        public ContentBlockManager(IContentBlockProvider provider) : base(provider) { }
    }
}
