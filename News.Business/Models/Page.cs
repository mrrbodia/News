using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace News.Business.Models
{
    public class Page : BaseModel
    {
        public virtual string Url { get; set; }

        public virtual string Title { get; set; }

        public virtual XmlDocument ContentBlocks { get; set; }
    }
}
