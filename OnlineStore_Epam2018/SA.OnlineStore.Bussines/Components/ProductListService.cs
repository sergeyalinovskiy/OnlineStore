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
        public static List<ProductListModel> productsInBox = new List<ProductListModel>()
        {
            new ProductListModel()
            {
                Id=1,
                ProductId=1,
                ProductName="11",
                Count=10
            }
        };

        public void DeleteProductInBoxById(int Id)
        {
            ProductListModel p = new ProductListModel();
            foreach (ProductListModel item in productsInBox)
            {
                if (item.Id == Id)
                {
                    p = item;
                }
            }
            productsInBox.Remove(p);
        }

        public void SaveProductListInBox(ProductListModel model)
        {
            productsInBox.Add(model);
        }

        public void EditProductListInBox(ProductListModel model)
        {
            productsInBox[model.Id].Id = model.Id;
            productsInBox[model.Id].ProductId = model.ProductId;
            productsInBox[model.Id].ProductName = model.ProductName;
            productsInBox[model.Id].Count = model.Count;
        }

        public ProductListModel GetProductListInBox(int Id)
        {
            return productsInBox.Where(t => t.Id == Id).FirstOrDefault();
        }

        public void AddNewItemInBox(ProductListModel product)
        {
            productsInBox.Add(product);
        }

        public IEnumerable<ProductListModel> GetProductListInBox()
        {
            return productsInBox;
        }

    }
}