namespace SA.OnlineStore.Common.Const
{
    #region Usings
    using System.Configuration;
    #endregion

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
             public const string GetSeasonNames = "GetSeasonNames";
             public const string SaveCategory = "SaveCategory";
             public const string GetCategoryByCategoryId = "GetCategoryByCategoryId";
        }
    }
}
