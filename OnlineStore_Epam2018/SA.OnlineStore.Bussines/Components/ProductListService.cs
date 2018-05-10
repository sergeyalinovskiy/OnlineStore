using SA.OnlineStore.Bussines.Entity;
using SA.OnlineStore.Bussines.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Components
{
    public class ProductListService : IProductListService
    {
        //private readonly IProductService _productService;
        //public ProductListService(IProductService productService)
        //{
        //    _productService = productService;
        //}
        public List<ProductList> productsInBox = new List<ProductList>()
        {
            new ProductList()
            {
                Id=1,
                ProductId=1,
                ProductName="11",
                Count=10
            }
        };

        public void DeleteProductInBoxById(int Id)
        {
            ProductList p = new ProductList();
            foreach (ProductList item in productsInBox)
            {
                if (item.Id == Id)
                {
                    p = item;
                }
            }
            productsInBox.Remove(p);
        }

        public void SaveProductListInBox(ProductList model)
        {
            productsInBox.Add(model);
        }

        public void EditProductListInBox(ProductList model)
        {
            productsInBox[model.Id].Id = model.Id;
            productsInBox[model.Id].ProductId = model.ProductId;
            productsInBox[model.Id].ProductName = model.ProductName;
            productsInBox[model.Id].Count = model.Count;
        }

        public ProductList GetProductListInBox(int Id)
        {
            return productsInBox.Where(t => t.Id == Id).FirstOrDefault();
        }

        public void AddNewItemInBox(ProductList product)
        {
            productsInBox.Add(product);
        }

        public IEnumerable<ProductList> GetProductListInBox()
        {
            return productsInBox;
        }



    }
}
