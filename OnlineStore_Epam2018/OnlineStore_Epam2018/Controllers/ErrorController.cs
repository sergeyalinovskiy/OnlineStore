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
            Response.StatusCode = 404;  
            return View("NotFound");
        }

        public ViewResult ServerError()
        {
            Response.StatusCode = 500;
            return View();
        }
        public ActionResult AccessPrivilegeError()
        {
            Response.StatusCode = 401;

            return RedirectToAction("Entrance","Login");
        }
    }
}