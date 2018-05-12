
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
        IEnumerable<ProductModel> ProductByCategory(int category);
        IEnumerable<ProductModel> ProductBySeason(int category);
        IEnumerable<ProductModel> ProductByPriceUp();
        IEnumerable<ProductModel> ProductByPriceDown();
        IEnumerable<ProductModel> ProductByProductName();
    }
}
