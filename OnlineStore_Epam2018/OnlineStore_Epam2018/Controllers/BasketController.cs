using OnlineStore_Epam2018.Models;
using SA.OnlineStore.Bussines.Entity;
using SA.OnlineStore.Bussines.Service;
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
        
        public ActionResult Index()
        {
            var products = ConvertToProductListViewModelList(_productListService.GetProductListInBox());

            return View(products);
        }


        public ProductListViewModel ConvertToProductListViewModel(ProductList model)
        {
            return new ProductListViewModel
            {
                Id = model.Id,
                ProductId = model.ProductId,
                ProductName= model.ProductName,
                Count= model.Count
            };
        }

        public IEnumerable<ProductListViewModel> ConvertToProductListViewModelList(IEnumerable<ProductList> modelList)
        {
            List<ProductListViewModel> convertProductList = new List<ProductListViewModel>();

            foreach (var item in modelList)
            {
                convertProductList.Add(ConvertToProductListViewModel(item));
            }
            return convertProductList;
        }

        //// GET: Basket
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}