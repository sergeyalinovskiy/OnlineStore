namespace OnlineStore_Epam2018.Controllers
{
    #region Usings
    using OnlineStore_Epam2018.Models;
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    #endregion
    public class SearchController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISeasonService _seasonService;
        private readonly ICategoryService _categoryService;
        private readonly ISearchService _searchService;
        public SearchController(IProductService productService, ISeasonService seasonService, ICategoryService categoryService,ISearchService searchService)
        {
            if (productService == null)
            {
                throw new ArgumentNullException("productService");
            }
            if (searchService == null)
            {
                throw new ArgumentNullException("searchService");
            }
            if (categoryService == null)
            {
                throw new ArgumentNullException("categoryService");
            }
            if (searchService == null)
            {
                throw new ArgumentNullException("searchService");
            }
       
             _productService = productService;
            _seasonService = seasonService;
            _categoryService = categoryService;
            _searchService = searchService;
        }
        

        public ActionResult Index(string category)
        {
            var viewModel = new ProductViewModel()
            {
                CategoryList = _categoryService.GetCategoryList(),
                SeasonList = _seasonService.GetSeasonList()
            };
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult OrdersData(string searchName,int category, int minValue, int maxValue)
        {
            List<ProductViewModel> products = ConvertToProductViewModelList(_productService.SearchProducts(searchName, category,minValue,maxValue));
           
            return PartialView(products);
        }

        public List<ProductViewModel> ConvertToProductViewModelList(List<Product> modelList)
        {
            List<ProductViewModel> convertProductList = new List<ProductViewModel>();

            foreach (var item in modelList)
            {
                convertProductList.Add(ConvertToViewModel(item));
            }
            return convertProductList;
        }

        public List<ProductViewModel> ConvertToProductViewModelList(IEnumerable<Product> modelList)
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
            var season = _seasonService.GetSeasonList().Where(s => s.SeasonId == model.Season.SeasonId).FirstOrDefault();
            var category = _categoryService.GetCategoryList().Where(c => c.CategoryId == model.Category.CategoryId).FirstOrDefault();
            return new ProductViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                CategoryName = category.CategoryName,
                SeasonName = season.SeasonName,
                Count = model.Count,
                Picture = model.Picture,
                Price = model.Price,
                Description = model.Description
            };
        }
    }
}