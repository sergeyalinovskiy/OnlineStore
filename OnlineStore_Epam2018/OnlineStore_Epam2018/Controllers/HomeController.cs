namespace OnlineStore_Epam2018.Controllers
{
    #region Usings
    using OnlineStore_Epam2018.Models;
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.Common.Logger;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    #endregion

    public class HomeController : Controller
    {
        private readonly ICommonLogger _myLoger;

        public HomeController(  ICommonLogger myLoger)
        {
            try
            {
                _myLoger = myLoger;
            }
            catch (NullReferenceException)
            {
                 View("Index","Error");
            }
        }

        public HomeController()
        {
              
        }

        public ActionResult Index()
        {
            return View();
        }


       
    }
}