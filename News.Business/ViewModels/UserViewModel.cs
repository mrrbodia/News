using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace News.Business.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        [Required]
        [EmailAddress]
        public virtual string Email { get; set; }

        [DataType(DataType.Password)]
        public virtual string Password { get; set; }

        public UserViewModel()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
