namespace OnlineStore_Epam2018.Controllers
{
    #region Usings
    using OnlineStore_Epam2018.Models;
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    #endregion

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

        public ActionResult Delete(int Id)
        {
            _productListService.DeleteProductInBoxById(Id);
            return RedirectToAction("Index");
        }
        
        public ActionResult Save(ProductListViewModel model)
        {
            ProductListModel prodInBascet = ConvertToProductListModel(model);
            _productListService.SaveProductListInBox(prodInBascet);
            return View("Index");
        }

        public ActionResult Edit(int Id)
        {
            var product = this.ConvertToProductViewModel(_productListService.GetProductListInBox(Id));
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(ProductListViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    var prod = this.ConvertToProductListModel(model);
                    this._productListService.SaveProductListInBox(prod);
                   
                    return RedirectToAction("Details", new { Id = model.Id });
                }
                catch (Exception)
                {
                    this.ModelState.AddModelError("", "Internal Exceptions");
                }
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            ProductListViewModel product = this.ConvertToProductViewModel(_productListService.GetProductListInBox(id));
            return View(product);
        }

        public ActionResult Index()
        {
            var products = ConvertToProductListViewModelList(_productListService.GetProductListInBox());
            return View(products);
        }



        public ProductListViewModel ConvertToProductViewModel(ProductListModel model)
        {
            return new ProductListViewModel
            {
                Id = model.Id,
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                Count = model.Count
            };
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