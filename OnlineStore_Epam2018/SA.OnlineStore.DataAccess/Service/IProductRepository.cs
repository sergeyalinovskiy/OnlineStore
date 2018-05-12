using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.DataAccess.Service
{
    public interface IProductRepository
    {
        void Delete(int Id);
        void Save(ProductModel model);
        ProductModel Get(int Id);
        List<ProductModel> GetList();
    }
}
