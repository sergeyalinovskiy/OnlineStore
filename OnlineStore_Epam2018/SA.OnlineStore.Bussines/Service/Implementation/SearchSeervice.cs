﻿namespace SA.OnlineStore.Bussines.Components
{
    #region Usings
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using System.Collections.Generic;
    using System.Linq;
    #endregion
    public class SearchSeervice : ISearchService
    {
        private readonly IProductService _productService;
        private readonly ISeasonService _seasonService;
        private readonly ICategoryService _categoryService;

        public SearchSeervice(IProductService productService, ISeasonService seasonService, ICategoryService categoryService)
        {
            _productService = productService;
            _seasonService = seasonService;
            _categoryService = categoryService;
        }

        public IEnumerable<Product> ProductByCategory(int category)
        {
            if (category < 1)
            {
                return null;
            }
            return _productService.GetProductLIstByCategory(category);
        }
    }
}