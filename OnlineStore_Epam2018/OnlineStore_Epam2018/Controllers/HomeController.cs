
using log4net;
using SA.OnlineStore.Common.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore_Epam2018.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICommonLogger _myLoger;

        public HomeController(ICommonLogger myLoger)
        {
            _myLoger = myLoger;
            
        }

        public HomeController()
        {
              
        }

        public ActionResult Index()
        {
            _myLoger.Info("Exception message");
            return View();
        }
    }
}