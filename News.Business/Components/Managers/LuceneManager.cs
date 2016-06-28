using Lucene.Net.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace News.Business.Components.Managers
{
    public class LuceneManager<T>
    {
        public Func<Document, T> DocProperty { get; set; }

        public Func<T, Document> TValueProperty { get; set; }

        public LuceneManager(Func<Document, T> property)
        {
            this.DocProperty = property;
        }

        public LuceneManager(Func<T, Document> property)
        {
            this.TValueProperty = property;
        }

        public T MapDocToTValue(Document doc)
        {
            return DocProperty(doc);
        }

        public Document MapTValueToDoc(T TValue)
        {
            return TValueProperty(TValue);
        }
    }
}