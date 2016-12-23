using News.Business.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Business.ViewModels
{
    public class PageDesignModel
    {
        private List<string> ContentBlocksData;

        public string Id { get; set; }

        public string Url { get; set; }

        public string Title { get; set; }

        public List<string> ContentBlocks
        {
            get
            {
                return ContentBlocksData;
            }
            set
            {
                value = value.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                ContentBlocksData = value;
            }
        }
        public IEnumerable<ContentBlock> ContentBlocksVariants { get; set; }

        public PageDesignModel()
        {
            ContentBlocks = new List<string>();
        }

        public PageDesignModel(Guid id)
            : this()
        {
            Id = id.ToString();
        }
    }
}
