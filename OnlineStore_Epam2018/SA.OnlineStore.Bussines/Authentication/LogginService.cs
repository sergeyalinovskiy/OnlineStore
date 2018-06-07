using Newtonsoft.Json;
using SA.OnlineStore.Common.Entity;
using System;
using System.Web;
using System.Web.Security;

namespace SA.OnlineStore.Bussines.Authentication
{
    public class LogginService : ILoginService
    {
        public void Login(string login, string password)
        {
            if (IsValidUser(login, password))
            {
                var user = GetUser(login);
                var userData = JsonConvert.SerializeObject(user);
                var ticket = new FormsAuthenticationTicket(1, user.Name, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);
                var encryptTicket = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        private bool IsValidUser(string login, string password)
        {
            if (login == password)
            {
                return true;
            }
            return false;
        }

        private User GetUser(string login)
        {
            Role role = new Role
            {
                RoleId = 1,
                Name = "admin"
            };

            User user = new User()
            {
                UserId = 1,
                Name = login,
              //  Roles = new Role[] { role }
            };

            return user;
        }
    }
}
