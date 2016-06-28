using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using News.Business.Components.Lucene.Attributes;
using Lucene.Net.Documents;

namespace News.Business.Models
{
    public class BaseModel
    {
        [Storable(Type = Field.Index.NOT_ANALYZED)]
        [ScaffoldColumn(false)]
        public virtual string Id { get; set; }

        public BaseModel()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
