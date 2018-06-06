namespace SA.OnlineStore.DataAccess
{
    using SA.OnlineStore.Common.Entity;
    #region Usings
    using SA.OnlineStore.DataAccess.Components;
    using SA.OnlineStore.DataAccess.Implements;
    using SA.OnlineStore.DataAccess.Service;
    using SA.OnlineStore.DataAccess.Service.Implementation;
    using StructureMap.Configuration.DSL;
    #endregion

    public class DataAccessDependencyRegistry :Registry
    {
        public DataAccessDependencyRegistry()
        {
            For<IRepository<Publicity>>().Use<PublicityRepository>();
            For<IRepository<Product>>().Use<ProductRepository>();
            For<IRepository<Category>>().Use<CategoryRepository>();
            For<IRepository<Season>>().Use<SeasonRepository>();
            For<IRealizationImplementation>().Use<RealizationImplementation>();

            For<IRepository<Basket>>().Use<BasketRepository>();
            For<IRepository<Order>>().Use<OrderRepository>();

            For<IRepository<User>>().Use<UserRepository>();
            For<IRepository<Role>>().Use<RoleRepository>();

            For<IRepository<Phone>>().Use<PhoneRepository>();
            For<IRepository<Email>>().Use<EmailRepository>();
        }
    }
}
