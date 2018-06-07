using System.Linq;
using System.Security.Principal;

namespace SA.OnlineStore.Bussines.Authentication
{
    class UserPrinciple : IPrincipal
    {
        public UserPrinciple(string userName)
        {
            Identity = new GenericIdentity(userName);
        }
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role)
        {
            return Roles.Contains(role);
        }
        public string UserName { get; set; }
        public string[] Roles { get; set; }
    }
}