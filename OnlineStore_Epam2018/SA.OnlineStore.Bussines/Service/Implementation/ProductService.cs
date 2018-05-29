namespace SA.OnlineStore.Bussines.Components
{
    #region Usings
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.DataAccess.Implements;
    using SA.OnlineStore.DataAccess.Service;
    using System.Collections.Generic;
    using System.Linq;
    #endregion

    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public void DeleteProductByProductId(int Id) 
        {
            _productRepository.Delete(Id);
        }

        public void EditProduct(Product model)
        {
            _productRepository.Update(model);
        }

        public Product GetProduct(int Id)
        {
            return _productRepository.GetById(Id);
        }

        public IEnumerable<Product> GetProductLIst()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetProductLIstByCategory(int category)
        {
            return _productRepository.GetAll().Where(x => x.CategoryId == category);
        }

        public void SaveProduct(Product model)
        {
            _productRepository.Create(model);
        }
    }
}