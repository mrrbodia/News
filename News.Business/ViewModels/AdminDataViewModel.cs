using News.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Business.ViewModels
{
    public class AdminDataViewModel
    {
        public IList<User> Users { get; set; }

        public IList<Role> Roles {get; set; }
    }
}
