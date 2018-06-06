using SA.OnlineStore.Bussines.Service;
using SA.OnlineStore.Common.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore_Epam2018.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICommonLogger _commonLogger;

        public UserController(IUserService userService, ICommonLogger commonLogger)
        {
            _userService = userService;
            _commonLogger = commonLogger;
        }

        public ActionResult GetUser(int id)
        {
            if (id <= 0)
            {
                _commonLogger.Info("value id in GetUser is not valid");
            }
            var user = _userService.GetUserById(id);

            return View();
        }
    }
}