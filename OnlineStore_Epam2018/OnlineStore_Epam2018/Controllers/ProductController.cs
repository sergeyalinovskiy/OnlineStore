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

            public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ProductController()
        {

        }
        // GET: Product
        public ActionResult Index()
        {
            var productList=this._productService.GetProductLIst().Select(product => this.ConvertToViewModel(product));
            return View(productList);
        }

        [HttpPost]
        public ActionResult Index(string Id)
        {
            return View("Index", (object)Id);
        }

        //public ActionResult OrdersData(string Category, string Season)
        //{
        //    IEnumerable<Product> data = _productService.GetProductLIst();

        //    if (!string.IsNullOrEmpty(Category) && Category != "All")
        //    {
        //        data = data.Where(e => Convert.ToString(e.CategoryId)== Category);
        //    }
        //    if (!string.IsNullOrEmpty(Season) && Season != "All")
        //    {
        //        data = data.Where(e => Convert.ToString(e.SeasonId) == Season);
        //    }
        //    return PartialView(data);
        //}

        public ActionResult Details(int Id)
        {
            var product = ConvertToViewModel(this._productService.GetProduct(Id));
            return View(product);
        }

        public ActionResult Create()
        {
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

        public ProductViewModel ConvertToViewModel(Product model)
        {
            return new ProductViewModel()
            {
                Id=model.Id,
                Name=model.Name,
                CategoryId= model.CategoryId,
                SeasonId= model.SeasonId,
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
                CategoryId = model.CategoryId,
                SeasonId = model.SeasonId,
                Count = model.Count,
                Picture = model.Picture,
                Price = model.Price,
                Description = model.Description
            };
        }
    }
}