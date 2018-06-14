using SA.OnlineStore.Common.Entity;
using SA.OnlineStore.DataAccess.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.DataAccess.Repositorys
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> SearchProducts(string name, int category, int minValue, int maxValue);
    }
}
