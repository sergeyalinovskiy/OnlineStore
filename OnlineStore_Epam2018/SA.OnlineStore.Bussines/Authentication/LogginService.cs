namespace SA.OnlineStore.Bussines.Authentication
{
    #region Usings
        using Newtonsoft.Json;
        using SA.OnlineStore.Common.Entity;
        using SA.OnlineStore.DataAccess.Repositorys;
        using System;
        using System.Web;
        using System.Web.Security;
    #endregion
    public class LogginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        public LogginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool Login(string login, string password)
        {
            if (IsValidUser(login, password))
            {
                var user = GetUser(login);
                var userData = JsonConvert.SerializeObject(user);
                var ticket = new FormsAuthenticationTicket(1, user.Login, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);
                var encryptTicket = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
                HttpContext.Current.Response.Cookies.Add(cookie);
                return true;
            }
            return false;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        private bool IsValidUser(string login, string password)
        {
            var user = GetUser(login);
            if ( user!=null && user.Password == password)
            {
                return true;
            }
            return false;
        }

        private User GetUser(string login)
        {
            var user = _userRepository.GetByLogin(login);
            return user;
        }
    }
}