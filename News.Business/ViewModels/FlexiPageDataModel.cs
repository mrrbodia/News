using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Business.ViewModels
{
    public class FlexiPageDataModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Url { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string XmlFields { get; set; }
    }
}
