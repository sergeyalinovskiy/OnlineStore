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

        public ActionResult Index(string category)
        {
            ViewBag.ListCategoryName = _categoryService.CategoryNameList();
            ViewBag.ListSeasonName = _seasonService.SeasonNameList();
            return View("Index", (object)category);
        }

        public ActionResult OrdersData(string category, string season, string sort, string searchName)
        {
            IEnumerable<ProductViewModel> products = ConvertToProductViewModelList(_productService.GetProductLIst());
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.CategoryName == category);
            }

            if (!string.IsNullOrEmpty(season))
            {
                products = products.Where(p => p.SeasonName == season);
            }

            if (!string.IsNullOrEmpty(sort))
            {
                if (sort == "цена по убыванию")
                {
                    products = products.OrderByDescending(p => p.Price);
                }
                if (sort == "цена по возрастанию")
                {
                    products = products.OrderBy(p => p.Price);
                }
            }

            if (!String.IsNullOrEmpty(searchName))
            {
                products = products.Where(p => p.Name == searchName);
            }
            return PartialView(products);
        }


        public IEnumerable<ProductViewModel> ConvertToProductViewModelList(IEnumerable<ProductModel> modelList)
        {
            List<ProductViewModel> convertProductList = new List<ProductViewModel>();

            foreach (var item in modelList)
            {
                convertProductList.Add(ConvertToViewModel(item));
            }
            return convertProductList;
        }

        public ProductViewModel ConvertToViewModel(ProductModel model)
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