using log4net;
using Newtonsoft.Json;
using OnlineStore_Epam2018.DependencyResolution;
using SA.OnlineStore.Bussines.Authentication;
using SA.OnlineStore.Common.Entity;
using SA.OnlineStore.Common.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace OnlineStore_Epam2018
{
    public class MvcApplication : System.Web.HttpApplication
    {
        

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            log4net.Config.XmlConfigurator.Configure();
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();

            var container = IoC.Initialize();

            var logger = container.GetInstance<ICommonLogger>();

            logger.Info(exception.Message + "   " + exception.StackTrace);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var cookie = HttpContext.Current.Request.Cookies.Get(FormsAuthentication.FormsCookieName);

            if(cookie != null)
            {
                var decryptCookie = FormsAuthentication.Decrypt(cookie.Value);
                var user = JsonConvert.DeserializeObject<User>(decryptCookie.UserData);
                HttpContext.Current.User = new UserPrincipal(user);
            }
        }
    }
}
