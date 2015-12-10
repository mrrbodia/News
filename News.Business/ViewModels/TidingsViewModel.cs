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
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Довжина строки повинна складати від 3 до 200 символів")]
        public virtual string Title { get; set; }

        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Довжина строки повинна складати від 3 до 1000 символів")]
        [Required(ErrorMessage = "Поле повинно бути заповнено")]
        public virtual string Discription { get; set; }

        public virtual DateTime PublishData { get; set; }

        public TidingsViewModel()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
