
using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Service
{
    public interface ISearchService
    {
        IEnumerable<ProductModel> ProductByCategory(string category);
        IEnumerable<ProductModel> ProductBySeason(string category);
        IEnumerable<ProductModel> ProductByPriceUp();
        IEnumerable<ProductModel> ProductByPriceDown();
        IEnumerable<ProductModel> ProductByProductName();
    }
}
