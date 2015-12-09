using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News.Business.Models;
using News.Business.IDataProviders;

namespace News.Business.Components.Managers
{
    public class RoleManager : BaseManager<Role, IRoleDataProvider>
    {
        public RoleManager(IRoleDataProvider provider) : base(provider) { }
    }
}
