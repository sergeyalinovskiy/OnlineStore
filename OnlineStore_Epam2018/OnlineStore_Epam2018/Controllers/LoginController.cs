using OnlineStore_Epam2018.Models;
using OnlineStore_Epam2018.RoleAttribut;
using SA.OnlineStore.Bussines.Authentication;
using System;
using System.Web.Mvc;

namespace OnlineStore_Epam2018.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            if (loginService == null)
            {
                throw new NullReferenceException("loginService");
            }
            _loginService = loginService;
        }

        public ActionResult Entrance()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Entrance(LoginViewModel model)
        {
            if (_loginService.Login(model.Login, model.Password))
            {
                _loginService.Login(model.Login, model.Password);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                this.ModelState.AddModelError("", "Internal Exceptions");
            }
            return View(model);
        }

        [Logged]
        public ActionResult Logout()
        {
            _loginService.Logout();
            return RedirectToAction("Index","Home");
        }
    }
}