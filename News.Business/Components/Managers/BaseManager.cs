﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News.Business.Models;
using News.Business.IDataProviders;

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
    }
}