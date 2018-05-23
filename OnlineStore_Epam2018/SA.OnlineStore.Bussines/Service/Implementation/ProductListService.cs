namespace SA.OnlineStore.Bussines.Components
{
    #region Usings
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using System.Collections.Generic;
    using System.Linq;
    #endregion

    public class ProductListService : IProductListService
    {
        public static List<ProductList> productsInBox = new List<ProductList>()
        {
            new ProductList()
            {
                Id=1,
                ProductId=1,
                ProductName="Инструкция по посадке и уходу",
                Count=1
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

        ProductList p = new ProductList();

        public void SaveProductListInBox(ProductList model)
        {
            foreach(ProductList item in productsInBox)
            {
                if (item.Id == model.Id)
                {
                    p = item;
                }
            }
            productsInBox.Remove(p);
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