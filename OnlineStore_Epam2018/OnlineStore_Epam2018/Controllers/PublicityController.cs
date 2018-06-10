using OnlineStore_Epam2018.Models;
using SA.OnlineStore.Bussines.Service;
using SA.OnlineStore.Common.Convert;
using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore_Epam2018.Controllers
{
    public class PublicityController : Controller
    {

        private readonly IPublicityService _publicityService;

        public PublicityController(IPublicityService publicityService)
        {
            if (publicityService == null)
            {
               throw new ArgumentNullException("publicityService");
            }
            _publicityService = publicityService;
        }


        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Publicity()
        {
            try
            {
                IEnumerable<PublicityViewModel> publicity = ConvertToPublicityViewModelList(_publicityService.GetPublicityList());
                return PartialView(publicity);
             }
            catch
            {
                List<Publicity> list = new List<Publicity>();
             list.Add(new Publicity()
            {
            Id = 11,
                    Name = "Реклама на сайте",
                    Picture = PictureConverter.ImageToByteArray(PictureConverter.GetImg("D:\\1111\\OnlineStore\\OnlineStore_Epam2018\\OnlineStore_Epam2018\\Content\\img\\picture_BelSladkoe.jpg")),
                    Text = "отсутствует"
                });
                return PartialView(ConvertToPublicityViewModelList(list));
    }

}

        public IEnumerable<PublicityViewModel> ConvertToPublicityViewModelList(IEnumerable<Publicity> modelList)
        {
            List<PublicityViewModel> convertPublicityList = new List<PublicityViewModel>();

            foreach (Publicity item in modelList)
            {
                convertPublicityList.Add(ConvertToViewModel(item));
            }
            return convertPublicityList;
        }

        public PublicityViewModel ConvertToViewModel(Publicity model)
        {
            return new PublicityViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Picture = Convert.ToBase64String(model.Picture),
                Text = model.Text
            };
        }

    }
}