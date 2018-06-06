namespace SA.OnlineStore.Bussines
{
    #region Usings
    using SA.OnlineStore.Bussines.Components;
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Bussines.Service.Implementation;
    using StructureMap.Configuration.DSL;
    #endregion

    public class BussinesDependencyRegistry : Registry 
    {
        public BussinesDependencyRegistry()
        {
            For<IProductService>().Use<ProductService>();
            For<IOrderService>().Use<OrderService>();
            For<ICategoryService>().Use<CategoryService>();
            For<ISeasonService>().Use<SeasonService>();
            For<ISearchService>().Use<SearchSeervice>();
            For<IBasketService>().Use<BasketService>();
            For<IUserService>().Use<UserService>();
            For<IEmailService>().Use<EmailService>();
            For<IPhoneService>().Use<PhoneService>();
        }
    }
}
