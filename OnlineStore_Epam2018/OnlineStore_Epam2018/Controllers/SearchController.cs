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
    public class SearchController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISeasonService _seasonService;
        private readonly ICategoryService _categoryService;
        private readonly ISearchService _searchService;
        public SearchController(IProductService productService, ISeasonService seasonService, ICategoryService categoryService,ISearchService searchService)
        {
            _productService = productService;
            _seasonService = seasonService;
            _categoryService = categoryService;
            _searchService = searchService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<ProductViewModel> products = ConvertToProductViewModelList(_productService.GetProductLIst());

            ViewBag.ListCategoryName = _categoryService.CategoryNameList();
            ViewBag.ListSeasonName = _seasonService.SeasonNameList();
            return View(products);
        }

        [HttpPost]
        public ActionResult Index(string category, string season, string sort)
        {
            IEnumerable<ProductViewModel> products = ConvertToProductViewModelList(_productService.GetProductLIst());
           
            ViewBag.ListCategoryName = _categoryService.CategoryNameList();
            ViewBag.ListSeasonName = _seasonService.SeasonNameList();

            if (!string.IsNullOrEmpty(category) && category != null)
            {
                 products = products.Where(p => p.CategoryName == category);
            }

            if (!string.IsNullOrEmpty(season) && season != null)
            {
                 products = products.Where(p => p.SeasonName == season);
            }

            if (!string.IsNullOrEmpty(sort) && sort != null)
            {
                if(sort=="цена по убыванию")
                {
                    products =products.OrderByDescending(p=>p.Price);
                }
                if (sort == "цена по возрастанию")
                {
                    products = products.OrderBy(p => p.Price);
                }
            }
            return View(products); 
        }

         //public ActionResult OrdersData(string category, string season)
        //{
        //    IEnumerable<ProductViewModel> products = ConvertToProductViewModelList(_productService.GetProductLIst());
        //    if (!string.IsNullOrEmpty(category) && category != null)
        //    {
        //        products = products.Where(p => p.CategoryName == category);
        //        return View(products);
        //    }
        //    if (!string.IsNullOrEmpty(season) && season != null)
        //    {
        //        products = products.Where(p => p.SeasonName == season);
        //        return View(products);
        //    }
        //    return PartialView(products);
        //}



        public IEnumerable<ProductViewModel> ConvertToProductViewModelList(IEnumerable<Product> modelList)
        {
            List<ProductViewModel> convertProductList = new List<ProductViewModel>();

            foreach (var item in modelList)
            {
                convertProductList.Add(ConvertToViewModel(item));
            }
            return convertProductList;
        }

        public ProductViewModel ConvertToViewModel(Product model)
        {
            return new ProductViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                CategoryName = model.CategoryName,
                SeasonName = model.SeasonName,
                Count = model.Count,
                Picture = model.Picture,
                Price = model.Price,
                Description = model.Description
            };
        }
    }
}