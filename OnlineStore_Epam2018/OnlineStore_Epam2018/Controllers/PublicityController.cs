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
                IEnumerable<PublicityViewModel> publicity = ConvertToPublicityViewModelList(_publicityService.GetDefaultList());
                return PartialView(publicity);

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