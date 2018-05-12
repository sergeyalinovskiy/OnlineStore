
using SA.OnlineStore.Bussines.Service;
using SA.OnlineStore.Common.Entity;
using SA.OnlineStore.DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Components
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void DeleteProductByProductId(int Id) 
        {
            _productRepository.Delete(Id);
        }

        public void EditProduct(ProductModel model)
        {
            _productRepository.Save(model);
        }

        public ProductModel GetProduct(int Id)
        {
            return _productRepository.Get(Id);
        }

        public IEnumerable<ProductModel> GetProductLIst()
        {
            return _productRepository.GetList();
        }

        public IEnumerable<ProductModel> GetProductLIstByCategory(int category)
        {
            return _productRepository.GetList().Where(x => x.CategoryId == category);
        }

        public void SaveProduct(ProductModel model)
        {
            _productRepository.Save(model);
        }
    }
}
