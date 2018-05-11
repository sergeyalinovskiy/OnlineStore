
using SA.OnlineStore.Bussines.Service;
using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Components
{
    public class ProductService : IProductService
    {
        private List<ProductModel> _products = new List<ProductModel>()
        {
            new ProductModel()
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
            new ProductModel()
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
            new ProductModel()
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
            new ProductModel()
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
            new ProductModel()
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
            new ProductModel()
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
                new ProductModel(){
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
            ProductModel p = new ProductModel();
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

        public void EditProduct(ProductModel model)
        {
            _products[model.Id].Name = model.Name;
            _products[model.Id].CategoryName = model.CategoryName;
            _products[model.Id].SeasonName = model.SeasonName;
            _products[model.Id].Picture = model.Picture;
            _products[model.Id].Description = model.Description;
            _products[model.Id].Count = model.Count;
            _products[model.Id].Price = model.Price;
        }


        public ProductModel GetProduct(int Id)
        {
            return _products.Where(t => t.Id == Id).FirstOrDefault();
        }

        public IEnumerable<ProductModel> GetProductLIst()
        {
            return _products;
        }

        public IEnumerable<ProductModel> GetProductLIstByCategory(string category)
        {
            return _products.Where(x => x.CategoryName == category);
        }

        public void SaveProduct(ProductModel model)
        {
            _products.Add(new ProductModel
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
