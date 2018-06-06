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

        [HttpPost]
        public ActionResult OrdersData(ProductViewModel model,string sort)
        {
            IEnumerable<ProductViewModel> products = ConvertToProductViewModelList(_productService.GetProductLIst());
            if (!string.IsNullOrEmpty(model.CategoryName))
            {
                products = products.Where(p => p.CategoryName == model.CategoryName);
            }

            if (!string.IsNullOrEmpty(model.SeasonName))
            {
                products = products.Where(p => p.SeasonName == model.SeasonName);
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

            if (!String.IsNullOrEmpty(model.Name))
            {
                products = products.Where(p => p.Name.Contains(model.Name));
            }
            return PartialView(products);
        }

        public ActionResult OrdersData(string category, string season, string sort, string searchName)
        {
            IEnumerable<ProductViewModel> products = ConvertToProductViewModelList(_productService.GetProductLIst());
           
            return PartialView(products);
        }

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