using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News.Business.Models;

namespace News.Business.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public virtual string Email { get; set; }

        public virtual string Password { get; set; }

        public UserViewModel()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
