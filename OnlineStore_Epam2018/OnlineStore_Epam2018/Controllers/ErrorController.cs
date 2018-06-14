namespace OnlineStore_Epam2018.Controllers
{
    #region Usings
    using System.Web.Mvc;
    #endregion

    public class ErrorController : Controller
    {
        public ViewResult Index()
        {
            return View("Error");
        }
        public ViewResult NotFound()
        {
            return View("NotFound");
        }

        public ViewResult ServerError()
        {
            return View();
        }
        public ActionResult AccessPrivilegeError()
        {
            return RedirectToAction("Entrance","Login");
        }
    }
}