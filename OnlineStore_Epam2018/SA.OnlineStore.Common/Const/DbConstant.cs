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


            //prod
            public const string GetProducts = "GetProducts";

            public const string GetProductListByProductId = "GetProductListByProductId";


            //Order
            public const string GetOrderByUserId = "GetOrderByUserId";
            public const string GetOrders = "GetOrders";
            public const string SaveOrder = "SaveOrder";
            public const string DeleteOrderByOrderId = "DeleteOrderByOrderId";
            public const string UpdateOrder = "UpdateOrder";


            public const string GetOrdersListById = "GetOrdersListById";
            public const string GetOrdersList = "GetOrdersList";

            //public const string DeleteBasketByOrderId = "DeleteBasketByOrderId";

            //basket
            public const string GetBasketByOrderId = "GetBasketByOrderId";
            public const string GetBasketById = "GetBasketById";
            public const string SaveProductInBasket = "SaveProductInBasket";
            public const string SaveNewProductInBasket = "SaveNewProductInBasket2";
            public const string DeleteProductInBasketById = "DeleteProductInBasketById";
            public const string GetBaskets = "GetBaskets";

            public const string GetProductsInBaskets = "GetProductsInBaskets";
            public const string GetProductsInBasketsByBasketId = "GetProductsInBasketsByBasketId";

        }
    }
}
