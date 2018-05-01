using SA.OnlineStore.Bussines.Entity;
using SA.OnlineStore.Bussines.Service;
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

        public IEnumerable<Product> ProductByCategory(string category)
        {
            return _productService.GetProductLIstByCategory(category);
        }

        public IEnumerable<Product> ProductByPriceDown()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> ProductByPriceUp()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> ProductByProductName()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> ProductBySeason(string category)
        {
            throw new NotImplementedException();
        }
    }
}
