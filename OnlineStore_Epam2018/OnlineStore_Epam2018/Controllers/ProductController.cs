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

        public ActionResult Index()
        {
            IEnumerable<ProductViewModel> productList = ConvertListToViewModel(_productService.GetProductLIst());
            return View(productList);
        }

        public ActionResult IndexSearch(int categoryId)
        {
            IEnumerable<ProductViewModel> productList = ConvertListToViewModel(_productService.GetProductLIst());

            IEnumerable<ProductViewModel> list = productList.Where(q => q.CategoryId == categoryId);
            return View("Index", list);
        }

        public ActionResult CategoryList()
        {
            var categorys = ConvertListToViewModel(_categoryService.GetCategoryList());

            return PartialView(categorys);
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
                    _productService.SaveProduct(product);
                    return RedirectToAction("Index");
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
            ProductViewModel product = ConvertToViewModel(_productService.GetProduct(id));
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            _productService.DeleteProductByProductId(id);
            return RedirectToAction("Index");
        }

        #region Convertation
        public List<ProductViewModel> ConvertListToViewModel(IEnumerable<ProductModel> models)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            foreach (ProductModel item in models)
            {
                products.Add(ConvertToViewModel(item));
            }
            return products;
        }
        public List<CategoryViewModel> ConvertListToViewModel(IEnumerable<CategoryModel> models)
        {
            List<CategoryViewModel> products = new List<CategoryViewModel>();
            foreach (CategoryModel item in models)
            {
                products.Add(ConvertToViewModel(item));
            }
            return products;
        }
        public CategoryViewModel ConvertToViewModel(CategoryModel model)
        {
            return new CategoryViewModel()
            {
                Id = model.CategoryId,
                CategoryName = model.CategoryName,
                ParentId = model.ParentId,
            };
        }
        public ProductViewModel ConvertToViewModel(ProductModel model)
        {
            return new ProductViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                CategoryId = model.CategoryId,
                SeasonId = model.SeasonId,
                Picture = model.Picture,
                Description = model.Description,
                Count = model.Count,
                Price = model.Price
            };
        }

        public ProductModel ConvertToBussinesModel(ProductViewModel model)
        {
            return new ProductModel()
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
        #endregion
    }
}

//public ActionResult Index(string category)
//{
//    ViewBag.ListCategoryName = _categoryService.CategoryNameList();
//    return View("Index", (object)category);
//}

//public ActionResult OrdersData(string category)
//{
//    IEnumerable<ProductViewModel> products = ConvertToProductViewModelList(_productService.GetProductLIst());
//    if (!string.IsNullOrEmpty(category) && category != "Все")
//    {
//        var newProductList = products.Where(p => p.CategoryName == category);
//        return PartialView(newProductList);
//    }
//    return PartialView(products);
//}

//public ActionResult AddInBox(int id)
//{
//    ProductModel prod = new ProductModel();
//    foreach (ProductModel item in _productService.GetProductLIst())
//    {
//        if (item.Id == id)
//        {
//            prod = item;
//        }
//    }
//    ProductList product = new ProductList()
//    {
//        ProductId = prod.Id,
//        ProductName = prod.Name,
//        Count = 1
//    };
//    _productListService.AddNewItemInBox(product);
//    return View();
//}

//public ActionResult Details(int id)
//{
//    var product = ConvertToViewModel(this._productService.GetProduct(id));
//    return View(product);
//}

//public ActionResult Create()
//{
//    ViewBag.ListSeasonName = _seasonService.SeasonNameList();
//    ViewBag.ListCategoryName = _categoryService.CategoryNameList();
//    return View();
//}

//[HttpPost]
//public ActionResult Create(ProductViewModel model)
//{
//    if (this.ModelState.IsValid)
//    {
//        try
//        {
//            var product = this.ConvertToBussinesModel(model);
//            this._productService.SaveProduct(product);
//            return RedirectToAction("Index");
//        }
//        catch (Exception)
//        {
//            this.ModelState.AddModelError("", "Internal Exceptions");
//        }
//    }
//    return View();
//}

//public ActionResult Edit(int Id)
//{
//    ViewBag.ListSeasonName = _seasonService.SeasonNameList();
//    ViewBag.ListCategoryName = _categoryService.CategoryNameList();
//    var product = this.ConvertToViewModel(this._productService.GetProduct(Id));
//    return View(product);
//}
//[HttpPost]
//public ActionResult Edit(ProductViewModel model)
//{
//    if (this.ModelState.IsValid)
//    {
//        try
//        {
//            var product = this.ConvertToBussinesModel(model);
//            this._productService.SaveProduct(product);
//            return RedirectToAction("Detail", new { Id = model.Id });
//        }
//        catch (Exception)
//        {
//            this.ModelState.AddModelError("", "Internal Exceptions");
//        }
//    }
//    return View();
//}

//public ActionResult Delete(int Id)
//{
//    this._productService.DeleteProductByProductId(Id);
//    return RedirectToAction("Index");
//}


//public IEnumerable<ProductViewModel> ConvertToProductViewModelList(IEnumerable<ProductModel> modelList)
//{
//    List<ProductViewModel> convertProductList = new List<ProductViewModel>();

//    foreach (var item in modelList)
//    {
//        convertProductList.Add(ConvertToViewModel(item));
//    }
//    return convertProductList;
//}

//public ProductViewModel ConvertToViewModel(ProductModel model)
//{
//    return new ProductViewModel()
//    {
//        Id = model.Id,
//        Name = model.Name,
//        CategoryName = model.CategoryName,
//        SeasonName = model.SeasonName,
//        Count = model.Count,
//        Picture = model.Picture,
//        Price = model.Price,
//        Description = model.Description
//    };
//}

//public ProductModel ConvertToBussinesModel(ProductViewModel model)
//{
//    return new Product()
//    {
//        Id = model.Id,
//        Name = model.Name,
//        CategoryName = model.CategoryName,
//        SeasonName = model.SeasonName,
//        Count = model.Count,
//        Picture = model.Picture,
//        Price = model.Price,
//        Description = model.Description
//    };
//}