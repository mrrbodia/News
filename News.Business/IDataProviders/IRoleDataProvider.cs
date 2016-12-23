using News.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Business.IDataProviders
{
    public interface IRoleDataProvider : IDataProvider<Models.Role>
    {
        Role GetRoleForName(string name);
    }
}
