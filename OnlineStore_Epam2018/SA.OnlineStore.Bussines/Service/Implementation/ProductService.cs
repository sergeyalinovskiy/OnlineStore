namespace SA.OnlineStore.Bussines.Components
{
    #region Usings
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.DataAccess.Service;
    using System.Collections.Generic;
    using System.Linq;
    #endregion

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

        public void EditProduct(Product model)
        {
            _productRepository.Save(model);
        }

        public Product GetProduct(int Id)
        {
            return _productRepository.Get(Id);
        }

        public IEnumerable<Product> GetProductLIst()
        {
            return _productRepository.GetList();
        }

        public IEnumerable<Product> GetProductLIstByCategory(int category)
        {
            return _productRepository.GetList().Where(x => x.CategoryId == category);
        }

        public void SaveProduct(Product model)
        {
            _productRepository.Save(model);
        }
    }
}