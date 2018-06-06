using log4net;
using OnlineStore_Epam2018.DependencyResolution;
using SA.OnlineStore.Common.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

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
    }
}
