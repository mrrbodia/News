using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Business.Models
{
    public class Tidings : BaseModel
    {
        public virtual string Title { get; set; }

        public virtual string Discription { get; set; }

        public virtual DateTime PublishData { get; set; }
    }
}
