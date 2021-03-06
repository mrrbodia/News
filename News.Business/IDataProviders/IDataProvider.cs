﻿using System;
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

        IList<T> GetList();

        T Get(string id);

        IList<T> GetListByField(string field, string value);

        T GetByField(string field, string value);
    }
}
