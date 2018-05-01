using SA.OnlineStore.Bussines.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Service
{
    public interface ISearchService
    {
        IEnumerable<Product> ProductByCategory(string category);
        IEnumerable<Product> ProductBySeason(string category);
        IEnumerable<Product> ProductByPriceUp();
        IEnumerable<Product> ProductByPriceDown();
        IEnumerable<Product> ProductByProductName();
    }
}
