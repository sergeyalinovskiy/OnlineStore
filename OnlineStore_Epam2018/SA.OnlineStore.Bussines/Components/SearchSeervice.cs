
using SA.OnlineStore.Bussines.Service;
using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Components
{
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

        public IEnumerable<ProductModel> ProductByCategory(string category)
        {
            return _productService.GetProductLIstByCategory(category);
        }

        public IEnumerable<ProductModel> ProductByPriceUp()
        {
            var productPriceDown = _productService.GetProductLIst().OrderBy(p => p.Price);
            return productPriceDown;
        }

        public IEnumerable<ProductModel> ProductByPriceDown()
        {
            var productPriceDown = _productService.GetProductLIst().OrderByDescending(p => p.Price);
            return productPriceDown;
        }

        public IEnumerable<ProductModel> ProductByProductName()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductModel> ProductBySeason(string category)
        {
            throw new NotImplementedException();
        }
    }
}
