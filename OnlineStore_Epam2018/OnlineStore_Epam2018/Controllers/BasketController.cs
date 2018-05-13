using OnlineStore_Epam2018.Models;

using SA.OnlineStore.Bussines.Service;
using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore_Epam2018.Controllers
{
    public class BasketController : Controller
    {
        private readonly IProductListService _productListService;
                
        public BasketController()
        {

        }
        public BasketController(IProductListService productListService)
        {
            _productListService = productListService;
        }
        
        public ActionResult Save(ProductListViewModel model)
        {
            ProductListModel prodInBascet = ConvertToProductListModel(model);
            _productListService.SaveProductListInBox(prodInBascet);
            return View("Index");
        }

        public ActionResult Index()
        {
            var products = ConvertToProductListViewModelList(_productListService.GetProductListInBox());

            return View(products);
        }


        public ProductListModel ConvertToProductListModel(ProductListViewModel model)
        {
            return new ProductListModel
            {
                Id = model.Id,
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                Count = model.Count
            };
        }




        public ProductListViewModel ConvertToProductListViewModel(ProductListModel model)
        {
            return new ProductListViewModel
            {
                Id = model.Id,
                ProductId = model.ProductId,
                ProductName= model.ProductName,
                Count= model.Count
            };
        }

        public IEnumerable<ProductListViewModel> ConvertToProductListViewModelList(IEnumerable<ProductListModel> modelList)
        {
            List<ProductListViewModel> convertProductList = new List<ProductListViewModel>();

            foreach (var item in modelList)
            {
                convertProductList.Add(ConvertToProductListViewModel(item));
            }
            return convertProductList;
        }
    }
}