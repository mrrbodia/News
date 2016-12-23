using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Business.Models.Admin
{
    public class ContentBlock : BaseModel
    {
        public virtual string Name { get; set; }

        public virtual BlockType Type { get; set; }

        public virtual string Content { get; set; }

        public enum BlockType
        {
            Html,
            Feed,
            Redirect
        }
    }
}
