using OnlineStore_Epam2018.Models;
using SA.OnlineStore.Bussines.Entity;
using SA.OnlineStore.Bussines.Service;
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

        public ProductController(IProductService productService, ICategoryService categoryService, ISeasonService seasonService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _seasonService = seasonService;
        }

        public ProductController()
        {

        }
        // GET: Product
        //public ActionResult Index()
        //{
        //    var productList=this._productService.GetProductLIst().Select(product => this.ConvertToViewModel(product));
        //    return View(productList);
        //}

        //[HttpPost]
        //public ActionResult Index(string Id)
        //{
        //    return View("Index", (object)Id);
        //}
        //public PartialViewResult PartialMetod()
        //{
        //    return PartialView();
        //}

        
        public ActionResult Index(string category)
        {
            IEnumerable<ProductViewModel> products = ConvertToProductViewModelList(_productService.GetProductLIst());

            ViewBag.ListCategoryName = _categoryService.CategoryNameList();

            if (category != null)
            {
                var newProductList = products.Where(p => p.CategoryName == category);
                return View(newProductList);
            }
            return View(products); 
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


        public IEnumerable<ProductViewModel> ConvertToProductViewModelList(IEnumerable<Product> modelList)
        {
            List<ProductViewModel> convertProductList = new List<ProductViewModel>();

            foreach(var item in modelList)
            {
                convertProductList.Add(ConvertToViewModel(item));
            }
            return convertProductList;
        }


        public ProductViewModel ConvertToViewModel(Product model)
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

        public Product ConvertToBussinesModel(ProductViewModel model)
        {
            return new Product()
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