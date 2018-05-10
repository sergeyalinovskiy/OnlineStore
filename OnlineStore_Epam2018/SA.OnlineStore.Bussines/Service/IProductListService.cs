
using SA.OnlineStore.Bussines.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Service
{
    public interface IProductListService
    {
        void DeleteProductInBoxById(int Id);
        void SaveProductListInBox(ProductList model);
        void EditProductListInBox(ProductList model);
        ProductList GetProductListInBox(int Id);
        IEnumerable<ProductList> GetProductListInBox();
        void AddNewItemInBox(ProductList product);
    }
}
