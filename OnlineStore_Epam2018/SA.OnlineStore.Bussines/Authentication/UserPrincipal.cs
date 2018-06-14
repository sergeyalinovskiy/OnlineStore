namespace SA.OnlineStore.Bussines.Authentication
{
    #region Usings
        using SA.OnlineStore.Common.Entity;
        using System.Linq;
        using System.Security.Principal;
    #endregion
    public class UserPrincipal : IPrincipal
    {
        public UserPrincipal(User user)
        {
            Identity = new GenericIdentity(user.Login);
            User = user;
        }

        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            return User.Role.Name.Contains(role);
        }
        
        public User User { get; set; }
    }
}