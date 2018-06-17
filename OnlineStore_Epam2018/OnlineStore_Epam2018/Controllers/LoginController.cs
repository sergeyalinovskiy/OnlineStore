namespace OnlineStore_Epam2018.Controllers
{
    #region Usings
        using OnlineStore_Epam2018.Models;
        using OnlineStore_Epam2018.RoleAttribut;
        using SA.OnlineStore.Bussines.Authentication;
        using System;
        using System.Web.Mvc;
    #endregion
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
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Entrance(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                _loginService.Login(model.Login, model.Password);
                
                if (!_loginService.Login(model.Login, model.Password))
                {
                    this.ModelState.AddModelError("", "Логин или пароль не верны");
                    return View(model);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                this.ModelState.AddModelError("", "Ошибка");
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