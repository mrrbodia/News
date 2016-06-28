using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Business.ViewModels
{
    public class CommentViewModel : BaseViewModel
    {
        public CommentViewModel()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public CommentViewModel(string tidingId)
        {
            this.Id = Guid.NewGuid().ToString();
            TidingId = tidingId;
        }

        [ScaffoldColumn(false)]
        public string TidingId { get; set; }

        [Required(ErrorMessage = "Это поле должно быть заполненым")]
        [StringLength(100, ErrorMessage = "Длина должна быть не больше 100 символов")]
        [DataType(DataType.Text)]
        public string AuthorName { get; set; }

        public virtual string AuthorId { get; set; }

        [ScaffoldColumn(false)]
        public virtual DateTime PostingTime { get; set; }

        [Required(ErrorMessage = "Это поле должно быть заполненым")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 1000 символов")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
    }
}
