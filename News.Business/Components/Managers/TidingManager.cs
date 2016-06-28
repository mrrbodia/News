using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News.Business.Models;
using News.Business.IDataProviders;
using System.IO;
using System.Xml.Serialization;
using News.Business.Components.Lucene;
using System.Globalization;

namespace News.Business.Components.Managers
{
    public class TidingManager : BaseManager<Tidings, ITidingsDataProvider>
    {
        public TidingManager(ITidingsDataProvider provider) : base(provider) { }

        private string luceneDirectory
        {
            get
            {
                return Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "App_Data", CultureInfo.CurrentCulture.ToString(), "lucene_index");
            }
        }

        public IList<Tidings> GetForAuthor(string id)
        {
            return provider.GetForAuthor(id);
        }

        public IList<string> Search(string title)
        {
            var searcher = new Searcher<Tidings>(luceneDirectory);
            var list = searcher.Search(title, "Title");
            var result = new List<string>();

            foreach (var item in list)
            {
                if (!result.Contains(item.Id))
                {
                    result.Add(item.Id);
                }
            }
            return result;
        }

        public void AddLuceneIndex(IList<Tidings> tidings)
        {
            var searcher = new Searcher<Tidings>(luceneDirectory);
            searcher.ClearIndex();
            searcher.AddUpdateIndex(tidings);
        }
    }
}
