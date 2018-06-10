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

            public const string SaveDefaultOrder = "SaveDefaultOrder";


            public const string GetStatusOrder = "GetStatusOrder";

            public const string GetOrdersListById = "GetOrdersListById";
            public const string GetOrdersList = "GetOrdersList";


            //basket
            public const string GetBasketByOrderId = "GetBasketByOrderId";
            public const string GetBasketById = "GetBasketById";
            public const string SaveProductInBasket = "SaveProductInBasket";
            public const string SaveNewProductInBasket = "SaveNewProductInBasket4";
            public const string DeleteProductInBasketById = "DeleteProductInBasketById";
            public const string GetBaskets = "GetBaskets";

            public const string GetProductsInBaskets = "GetProductsInBaskets";
            public const string GetProductsInBasketsByBasketId = "GetProductsInBasketsByBasketId";



            //User
            public const string SaveUser = "SaveUser";
            public const string SaveUserEmail = "SaveUserEmail";
            public const string SaveUserPhone = "SaveUserPhone";
            public const string SaveUserRole = "SaveUserRole";

            public const string GetUserList = "GetUserList";
            public const string GetUserListByUserId = "GetUserListByUserId";

            public const string GetRoles = "GetRoles";
            public const string GetPhonesByUserId = "GetPhonesByUserId";
            public const string GetEmailsByUserId = "GetEmailsByUserId";
            public const string GetEmailsList = "GetEmailsList";
            public const string GetPhonesList = "GetPhonesList";


            public const string DeleteUserByUserId = "DeleteUserByUserId";
            public const string DeletePhoneByUserId = "DeletePhoneByUserId";
            public const string DeleteEmailByUserId = "DeleteEmailByUserId";


            public const string GetUserByLogin = "GetUserByLogin";

        }
    }
}
