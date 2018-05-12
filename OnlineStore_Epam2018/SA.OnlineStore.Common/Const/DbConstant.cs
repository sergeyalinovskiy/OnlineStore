using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Common.Const
{
    public static class DbConstant
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static class Command
        {
             public const string GetProductList = "GetProductList";
             public const string GetProductByProductId = "GetProductByProductId";
             public const string GetCategoryList = "GetCategoryList";
             public const string GetSeasonList = "GetSeasonList";
             public const string SaveProduct = "SaveProduct";
             public const string DeleteProductByProductId = "DeleteProductByProductId";
             public const string DeleteCategoryByCategoryId = "DeleteCategoryByCategoryId";
        }
    }
}
