﻿using System;
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
    public class TidingManager : BaseManager<Tidings, ITidingsDataProvider>
    {
        public TidingManager(ITidingsDataProvider provider) : base(provider) { }

        public IList<Tidings> GetForAuthor(string id)
        {
            return provider.GetForAuthor(id);
        }
    }
}