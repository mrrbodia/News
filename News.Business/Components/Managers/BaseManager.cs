using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News.Business.Models;
using News.Business.IDataProviders;
using System.IO;
using System.Xml.Serialization;

namespace News.Business.Components.Managers
{
    public abstract class BaseManager<T, TProvider>
        where T : BaseModel
        where TProvider : IDataProvider<T>
    {
        protected TProvider provider;

        protected BaseManager(TProvider provider)
        {
            this.provider = provider;
        }

        public virtual void Create(T model)
        {
            provider.Create(model);
        }

        public virtual void Update(T model)
        {
            provider.Update(model);
        }

        public virtual void Delete(string id)
        {
            provider.Delete(id);
        }

        public virtual IList<T> GetList()
        {
            return provider.GetList();
        }

        public string Serialize(IList<T> model)
        {
            try
            {
                var stringwriter = new StringWriter();
                var serializer = new XmlSerializer(typeof(List<T>));
                serializer.Serialize(stringwriter, model);
                return stringwriter.ToString();
            }
            catch
            {
                throw;
            }
        }

        public IList<T> Deserialize(string xml)
        {
            try
            {
                var stringReader = new StringReader(xml);
                var serializer = new XmlSerializer(typeof(List<T>));
                return (IList<T>)serializer.Deserialize(stringReader);
            }
            catch
            {
                throw;
            }
        }
    }
}
