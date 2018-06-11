namespace SA.OnlineStore.Bussines.Components
{
    #region Usings
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Cache;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.DataAccess.Implements;
    using SA.OnlineStore.DataAccess.Service;
    using System.Collections.Generic;
    using System.Linq;
    #endregion

    public class ProductService : IProductService
    {
        private readonly IStoreCache _cache;
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository, IStoreCache cache)
        {
            _productRepository = productRepository;
            _cache = cache;
        }

        public void DeleteProductByProductId(int Id) 
        {
            if (Id > 0)
            {
                _productRepository.Delete(Id);
            }
        }

        public void EditProduct(Product model)
        {
            if (model != null)
            {
                _productRepository.Update(model);
            }
        }

        public Product GetProduct(int Id)
        {
            if (Id < 1)
            {
                return null;
            }
            return _productRepository.GetById(Id);
        }

        public IEnumerable<Product> GetProductLIst()
        {
            IReadOnlyCollection<Product> list = _cache.GetCache("ProductCache");
            if (list == null)
            {
                 list = _productRepository.GetAll();
                _cache.Create("ProductCache", list, 30);
            }
            return list;
        }

        public IEnumerable<Product> GetProductLIstByCategory(int category)
        {
            if (category < 0)
            {
                return null;
            }
            return _productRepository.GetAll().Where(x => x.Category.CategoryId == category);
        }

        public void SaveProduct(Product model)
        {
            if (model != null)
            {
                _productRepository.Create(model);
            }
        }
    }
}