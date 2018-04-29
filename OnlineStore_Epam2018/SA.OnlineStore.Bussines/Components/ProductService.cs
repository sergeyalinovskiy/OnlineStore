using SA.OnlineStore.Bussines.Entity;
using SA.OnlineStore.Bussines.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Components
{
    public class ProductService : IProductService
    {
        private List<Product> _products = new List<Product>()
        {
            new Product()
            {
                Id=1,
                Name="product",
                CategoryId=1,
                SeasonId=1,
                Picture="pic",
                Description="desc",
                Count=1,
                Price=1
            },
            new Product()
            {
                Id=2,
                Name="product2",
                CategoryId=2,
                SeasonId=2,
                Picture="pic2",
                Description="desc2",
                Count=2,
                Price=2
            }
        };
        public void DeleteProductByProductId(int Id)
        {
            _products.RemoveAt(Id);
        }

        public void EditProduct(Product model)
        {
            _products[model.Id].Name = model.Name;
            _products[model.Id].CategoryId = model.CategoryId;
            _products[model.Id].SeasonId = model.SeasonId;
            _products[model.Id].Picture = model.Picture;
            _products[model.Id].Description = model.Description;
            _products[model.Id].Count = model.Count;
            _products[model.Id].Price = model.Price;
        }


        public Product GetProduct(int Id)
        {
            return _products.Where(t => t.Id == Id).FirstOrDefault();
        }

        public IEnumerable<Product> GetProductLIst()
        {
            return _products;
        }

        public void SaveProduct(Product model)
        {
            _products.Add(new Product
            {
                Name = model.Name,
                CategoryId = model.CategoryId,
                SeasonId = model.SeasonId,
                Picture = model.Picture,
                Description = model.Description,
                Count = model.Count,
                Price = model.Price
            });
        }
    }
}
