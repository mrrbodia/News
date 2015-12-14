using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace News.Business.Providers
{
    public class XmlProvider<T>
    {
        public static string Serialize(IList<T> model)
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

        public static IList<T> Deserialize(string xml)
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
