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
                CategoryName="Яблоня",
                SeasonName="лето",
                Picture="pic",
                Description="desc",
                Count=1,
                Price=12
            },
            new Product()
            {
                Id=2,
                Name="product2",
                CategoryName="Груша",
                SeasonName="осень",
                Picture="pic2",
                Description="desc2",
                Count=2,
                Price=23
            },
            new Product()
            {
                Id=3,
                Name="product3",
                CategoryName="Вишня",
                SeasonName="зима",
                Picture="pic3",
                Description="desc3",
                Count=3,
                Price=31
            },
            new Product()
            {
                Id=4,
                Name="product",
                CategoryName="Яблоня",
                SeasonName="лето",
                Picture="pic",
                Description="desc",
                Count=1,
                Price=14
            },
            new Product()
            {
                Id=5,
                Name="product2",
                CategoryName="Груша",
                SeasonName="осень",
                Picture="pic2",
                Description="desc2",
                Count=2,
                Price=21
            },
            new Product()
            {
                Id=6,
                Name="product3",
                CategoryName="Вишня",
                SeasonName="зима",
                Picture="pic3",
                Description="desc3",
                Count=3,
                Price=33
            },
                new Product(){
                Id=1,
                Name="product",
                CategoryName="Яблоня",
                SeasonName="осень",
                Picture="pic",
                Description="desc",
                Count=1,
                Price=14
            },
        };
        public void DeleteProductByProductId(int Id)   //переделать!!!! 
        {
            Product p = new Product();
            //_products.RemoveAt(Id);
            foreach(var item in _products)
            {
                if (item.Id == Id)
                {
                    p = item;
                }
            }
            _products.Remove(p);

        }

        public void EditProduct(Product model)
        {
            _products[model.Id].Name = model.Name;
            _products[model.Id].CategoryName = model.CategoryName;
            _products[model.Id].SeasonName = model.SeasonName;
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

        public IEnumerable<Product> GetProductLIstByCategory(string category)
        {
            return _products.Where(x => x.CategoryName == category);
        }

        public void SaveProduct(Product model)
        {
            _products.Add(new Product
            {
                Name = model.Name,                
                CategoryName=model.CategoryName,
                SeasonName = model.SeasonName,
                Picture = model.Picture,
                Description = model.Description,
                Count = model.Count,
                Price = model.Price
            });
        }
    }
}
