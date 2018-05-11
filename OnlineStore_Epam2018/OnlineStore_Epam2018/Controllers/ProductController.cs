using OnlineStore_Epam2018.Models;

using SA.OnlineStore.Bussines.Service;
using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineStore_Epam2018.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISeasonService _seasonService;
        private readonly IProductListService _productListService;

        public ProductController(IProductService productService, ICategoryService categoryService, ISeasonService seasonService, IProductListService productListService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _seasonService = seasonService;
            _productListService = productListService;
        }

        public ProductController()
        {

        }
        
        public ActionResult Index(string category)
        {
            ViewBag.ListCategoryName = _categoryService.CategoryNameList();
            return View("Index", (object)category);
        }

        public ActionResult OrdersData(string category)
        {
            IEnumerable<ProductViewModel> products = ConvertToProductViewModelList(_productService.GetProductLIst());
            if (!string.IsNullOrEmpty(category) && category != "Все")
            {
                var newProductList = products.Where(p => p.CategoryName == category);
                return PartialView(newProductList);
            }
            return PartialView(products);
        } 

        public ActionResult AddInBox(int id)
        {
            ProductModel prod = new ProductModel();
            foreach(ProductModel item in _productService.GetProductLIst())
            {
                if (item.Id == id)
                {
                    prod = item;
                }
            }
            ProductListModel product = new ProductListModel()
            {
                ProductId = prod.Id,
                ProductName = prod.Name,
                Count = 1
            };
             _productListService.AddNewItemInBox(product);
            return View();
        }

        public ActionResult Details(int id)
        {
            var product = ConvertToViewModel(this._productService.GetProduct(id));
            return View(product);
        }

        public ActionResult Create()
        {
            ViewBag.ListSeasonName = _seasonService.SeasonNameList();
            ViewBag.ListCategoryName = _categoryService.CategoryNameList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    var product = this.ConvertToBussinesModel(model);
                    this._productService.SaveProduct(product);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    this.ModelState.AddModelError("", "Internal Exceptions");
                }
            }
            return View();
        }

        public ActionResult Edit(int Id)
        {
            ViewBag.ListSeasonName = _seasonService.SeasonNameList();
            ViewBag.ListCategoryName = _categoryService.CategoryNameList();
            var product = this.ConvertToViewModel(this._productService.GetProduct(Id));
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    var product = this.ConvertToBussinesModel(model);
                    this._productService.SaveProduct(product);
                    return RedirectToAction("Detail", new { Id=model.Id});
                }
                catch (Exception)
                {
                    this.ModelState.AddModelError("", "Internal Exceptions");
                }
            }
            return View();
        }

        public ActionResult Delete(int Id)
        {
            this._productService.DeleteProductByProductId(Id);
            return RedirectToAction("Index");
        }


        public IEnumerable<ProductViewModel> ConvertToProductViewModelList(IEnumerable<ProductModel> modelList)
        {
            List<ProductViewModel> convertProductList = new List<ProductViewModel>();

            foreach(var item in modelList)
            {
                convertProductList.Add(ConvertToViewModel(item));
            }
            return convertProductList;
        }

        public ProductViewModel ConvertToViewModel(ProductModel model)
        {
            return new ProductViewModel()
            {
                Id=model.Id,
                Name=model.Name,
                CategoryName=model.CategoryName,
                SeasonName= model.SeasonName,
                Count=model.Count,
                Picture= model.Picture,
                Price= model.Price,
                Description=model.Description
            };
        }

        public ProductModel ConvertToBussinesModel(ProductViewModel model)
        {
            return new ProductModel()
            {
                Id = model.Id,
                Name = model.Name,
                CategoryName= model.CategoryName,
                SeasonName = model.SeasonName,
                Count = model.Count,
                Picture = model.Picture,
                Price = model.Price,
                Description = model.Description
            };
        }
    }
}