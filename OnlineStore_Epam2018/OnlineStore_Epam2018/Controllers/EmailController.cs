using Newtonsoft.Json;
using SA.OnlineStore.Bussines.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore_Epam2018.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }


        [HttpPost]
        public JsonResult GetEmailsByUserId(int userId)
        {
            var emails = _emailService.GetEmailsByUserId(userId);
            var emailsData = JsonConvert.SerializeObject(emails);
            return Json(emailsData, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Index()
        {
            return View();
        }
    }
}