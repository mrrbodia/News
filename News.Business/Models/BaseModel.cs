using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace News.Business.Models
{
    public class BaseModel
    {
        [ScaffoldColumn(false)]
        public virtual string Id { get; set; }

        public BaseModel()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
