using OnlineStore_Epam2018.Models;
using OnlineStore_Epam2018.RoleAttribut;
using SA.OnlineStore.Bussines.Authentication;
using System.Web.Mvc;

namespace OnlineStore_Epam2018.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }


        public ActionResult Entrance()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Entrance(LoginViewModel model)
        {
            _loginService.Login(model.Login, model.Password);
            return RedirectToAction("Index", "Home");


        }
        [Logged]
        public ActionResult Logout()
        {
            _loginService.Logout();
            return RedirectToAction("Index","Home");
        }
    }
}