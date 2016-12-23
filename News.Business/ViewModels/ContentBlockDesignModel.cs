using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News.Business.Models.Admin;

namespace News.Business.ViewModels
{
    public class ContentBlockDesignModel
    {
        public string Id { get; set; }

        public ContentBlock.BlockType Type { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public ContentBlockDesignModel()
        {

        }

        public ContentBlockDesignModel(Guid id)
            : this()
        {
            Id = id.ToString();
        }
    }
}
