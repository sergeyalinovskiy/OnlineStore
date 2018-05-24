namespace OnlineStore_Epam2018.Controllers
{
    #region Usings
    using OnlineStore_Epam2018.Models;
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.Common.Logger;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    #endregion

    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISeasonService _seasonService;
        private readonly IProductListService _productListService;
        private readonly ICommonLogger _myLoger;

        public ProductController(IProductService productService, ICategoryService categoryService, ISeasonService seasonService, IProductListService productListService, ICommonLogger myLoger)
        {
            try
            {
                if (productService == null)
                {
                    throw new ArgumentNullException("productService");
                }
                if (productListService == null)
                {
                    throw new ArgumentNullException("productListService");
                }
                if (categoryService == null)
                {
                    throw new ArgumentNullException("categoryService");
                }
                if (seasonService == null)
                {
                    throw new ArgumentNullException("seasonService");
                }
                _productService = productService;
                _categoryService = categoryService;
                _seasonService = seasonService;
                _productListService = productListService;
                _myLoger = myLoger;
            }
            catch (NullReferenceException)
            {
                View("Create");
            }
            
        }

        public ProductController()
        {

        }

        public ActionResult Index()
        {
            IEnumerable<ProductViewModel> productList = ConvertListToViewModel(_productService.GetProductLIst());
            if (productList == null)
            {
                return PartialView("ErrorPartialView");
            }
            return View("Index", productList);
        }

        public ActionResult AddInBox(int id)
        {
            Product prod = new Product();
            foreach (Product item in _productService.GetProductLIst())
            {
                if (item.Id == id)
                {
                    prod = item;
                }
            }
            ProductList product = new ProductList()
            {
                Id = 3,
                ProductId = prod.Id,
                ProductName = prod.Name,
                Count = 1
            };
            _productListService.AddNewItemInBox(product);
            return View();
        }

        public ActionResult IndexSearch(int? id)
        {
            IEnumerable<Product> productList = _productService.GetProductLIst();
            if (id != null)
            {
                productList = productList.Where(m => m.CategoryId == id);
                IEnumerable<ProductViewModel> list = ConvertListToViewModel(productList);
                return View("Index", list);
            }  
           
            IEnumerable<ProductViewModel> list2 = ConvertListToViewModel(productList);
            return View("Index", list2);
        }

        public ActionResult CategoryList()
        {
            var categorys = ConvertListToViewModel(_categoryService.GetCategoryList().Where(m=>m.ParentId==0));

            return PartialView(categorys);
        }

        public ActionResult SubCategoryList(int id)
        {
            var categorys = ConvertListToViewModel(_categoryService.GetCategoryList().Where(m => m.ParentId == id));

            return PartialView("SubCategoryList",categorys);
        }




        public ActionResult Create()
        {
            var viewModel = new ProductViewModel();
            viewModel.Picture = "picture_default.jpg";
            viewModel = AddAllSelectLists(viewModel);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var product = this.ConvertToBussinesModel(model);
                _productService.SaveProduct(product);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Exception");
            }

            model = AddAllSelectLists(model);

            return View(model);
        }

        public ActionResult Details(int id)
        {
            ProductViewModel product = ConvertToViewModel(_productService.GetProduct(id));
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            _productService.DeleteProductByProductId(id);
            return RedirectToAction("Index");
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
                    _productService.SaveProduct(product);
                    return RedirectToAction("Details", new { Id = model.Id });
                }
                catch (Exception)
                {
                    this.ModelState.AddModelError("", "Internal Exceptions");
                }
            }
            return View();
        }

        #region Convertation
        public List<ProductViewModel> ConvertListToViewModel(IEnumerable<Product> models)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            foreach (Product item in models)
            {
                products.Add(ConvertToViewModel(item));
            }
            return products;
        }

        public ProductViewModel AddAllSelectLists(ProductViewModel model)
        {
            model.CategoryNameList = _categoryService.CategoryNameList();
            model.SeasonNameList = _seasonService.SeasonNameList();
            return model;
        }

        public List<CategoryViewModel> ConvertListToViewModel(IEnumerable<Category> models)
        {
            List<CategoryViewModel> products = new List<CategoryViewModel>();
            foreach (Category item in models)
            {
                products.Add(ConvertToViewModel(item));
            }
            return products;
        }

        public CategoryViewModel ConvertToViewModel(Category model)
        {
            var category = _categoryService.GetCategoryList().Where(c => c.ParentId == model.CategoryId).FirstOrDefault();
            return new CategoryViewModel()
            {
                CategoryId = model.CategoryId,
                CategoryName = model.CategoryName,
                ParentId = model.ParentId
            };
        }

        public ProductViewModel ConvertToViewModel(Product model)
        {
            var season = _seasonService.GetSeasonList().Where(s => s.SeasonId == model.SeasonId).FirstOrDefault();
            var category = _categoryService.GetCategoryList().Where(c => c.CategoryId == model.CategoryId).FirstOrDefault();
            return new ProductViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                CategoryName = category.CategoryName,
                SeasonName = season.SeasonName,
                Picture = model.Picture,
                Description = model.Description,
                Count = model.Count,
                Price = model.Price
            };
        }

        public Product ConvertToBussinesModel(ProductViewModel model)
        {
            var season = _seasonService.GetSeasonList().Where(s => s.SeasonName == model.SeasonName).FirstOrDefault();
            var category = _categoryService.GetCategoryList().Where(c => c.CategoryName == model.CategoryName).FirstOrDefault();
            return new Product()
            {
                Id = model.Id,
                Name = model.Name,
                CategoryId = category.CategoryId,
                SeasonId = season.SeasonId,
                Count = model.Count,
                Picture = model.Picture,
                Price = model.Price,
                Description = model.Description
            };
        }
        #endregion
    }
}