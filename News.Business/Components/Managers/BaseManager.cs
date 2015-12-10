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

        public string Serialize<T>(T dataToSerialize)
        {
            try
            {
                var stringwriter = new System.IO.StringWriter();
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stringwriter, dataToSerialize);
                string str = stringwriter.ToString();
                return str;
            }
            catch
            {
                throw;
            }
        }

        public T Deserialize<T>(string xmlText)
        {
            try
            {
                var stringReader = new System.IO.StringReader(xmlText);
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
            catch
            {
                throw;
            }
        }
    }
}
