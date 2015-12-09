using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News.Business.Models;

namespace News.Business.IDataProviders
{
    public interface IUserDataProvider : IDataProvider<Models.User>
    {
        User GetByEmail(string email);
    }
}
