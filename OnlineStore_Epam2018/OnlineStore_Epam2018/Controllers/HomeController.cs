﻿namespace OnlineStore_Epam2018.Controllers
{
    #region Usings
    using OnlineStore_Epam2018.Models;
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.Common.Logger;
    using System.Collections.Generic;
    using System.Web.Mvc;

    #endregion

    public class HomeController : Controller
    {
        private readonly ICommonLogger _myLoger;
        private readonly IPublicityService _publicityService;

        public HomeController(ICommonLogger myLoger, IPublicityService publicityService)
        {
            _myLoger = myLoger;
            _publicityService = publicityService;
        }

        public HomeController()
        {
              
        }

        public ActionResult Index()
        {
            _myLoger.Info("Exception message");
            return View(ConvertToProductViewModelList(_publicityService.GetPublicityList()));
        }

        public IEnumerable<PublicityViewModel> ConvertToProductViewModelList(IEnumerable<PublicityModel> modelList)
        {
            List<PublicityViewModel> convertPublicityList = new List<PublicityViewModel>();

            foreach (PublicityModel item in modelList)
            {
                convertPublicityList.Add(ConvertToViewModel(item));
            }
            return convertPublicityList;
        }

        public PublicityViewModel ConvertToViewModel(PublicityModel model)
        {
            return new PublicityViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Text = model.Text
            };
        }


    }
}