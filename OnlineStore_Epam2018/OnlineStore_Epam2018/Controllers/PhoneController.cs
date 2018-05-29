using Newtonsoft.Json;
using SA.OnlineStore.Bussines.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore_Epam2018.Controllers
{
    public class PhoneController : Controller
    {
        private readonly IPhoneService _phoneService;

        public PhoneController(IPhoneService phoneService)
        {
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