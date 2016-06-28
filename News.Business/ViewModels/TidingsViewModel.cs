using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace News.Business.ViewModels
{
    public class TidingsViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Поле повинно бути заповнено")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "Довжина строки повинна складати від 1 до 255 символів")]
        public virtual string Title { get; set; }

        [StringLength(2000, MinimumLength = 1, ErrorMessage = "Довжина строки повинна складати від 1 до 2000 символів")]
        [Required(ErrorMessage = "Поле повинно бути заповнено")]
        public virtual string Discription { get; set; }

        public virtual string AuthorId { get; set; }

        public virtual DateTime PublishData { get; set; }

        public TidingsViewModel()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
