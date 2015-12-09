using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Business.IDataProviders
{
    public interface IDataProvider<T>
    {
        void Create(T model);

        void Update(T model);

        void Delete(string id);
    }
}
