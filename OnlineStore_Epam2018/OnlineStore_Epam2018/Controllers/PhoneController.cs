namespace OnlineStore_Epam2018.Controllers
{
    #region Usings
        using Newtonsoft.Json;
        using SA.OnlineStore.Bussines.Service;
        using System;
        using System.Web.Mvc;
    #endregion
    public class PhoneController : Controller
    {
        private readonly IPhoneService _phoneService;

        public PhoneController(IPhoneService phoneService)
        {
            if (phoneService == null)
            {
                throw new NullReferenceException("phoneService");
            }
            _phoneService = phoneService;
        }

        public JsonResult GetEmailByUserId(int userId)
        {
            var phones = _phoneService.GetPhnesByUserId(userId);
            var phonesData = JsonConvert.SerializeObject(phones);
            return Json(phonesData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}