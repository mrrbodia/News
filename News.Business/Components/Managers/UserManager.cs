using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News.Business.Models;
using News.Business.IDataProviders;
using System.Web;
using News.Business.Components;

namespace News.Business.Components.Managers
{
    public class UserManager : BaseManager<User, IUserDataProvider>
    {
        public UserManager(IUserDataProvider provider) : base(provider) { }

        public bool UserRole { get; set; }

        public User GetByEmail(string email)
        {
            return provider.GetByEmail(email);
        }

        public bool IsRoleAssigned(string email, string password)
        {
            var user = provider.GetByEmail(email);

            if (user == null)
            {
                return false;
            }

            return CheckCorrectPassword(user, password);
        }

        public bool IsPasswordValid(User user, string password)
        {
            return HashDecoder.VerifyHash(password, user.Password, user.PasswordSalt);
        }

        private bool CheckCorrectPassword(User user, string password)
        {
            var passValid = IsPasswordValid(user, password);
            if (passValid)
            {
                SetRole(user);
            }
            return passValid;
        }

        private void SetRole(User user)
        {
            HttpContext.Current.User = new System.Security.Principal
                        .GenericPrincipal(new System.Security.Principal.GenericIdentity(user.Email), new[] { user.Role.Name });
        }
    }
}
