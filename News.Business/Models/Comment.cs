using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Business.Models
{
    public class Comment : BaseModel
    {

        public virtual string TidingId { get; set; }

        public virtual string AuthorId { get; set; }

        public virtual string Text { get; set; }

        public virtual string AuthorName { get; set; }

        public virtual DateTime PostingTime { get; set; }
    }
}
