namespace SA.OnlineStore.DataAccess
{
    #region Usings
    using SA.OnlineStore.DataAccess.Components;
    using SA.OnlineStore.DataAccess.Service;
    using StructureMap.Configuration.DSL;
    #endregion

    public class DataAccessDependencyRegistry :Registry
    {
        public DataAccessDependencyRegistry()
        {
            For<IPublicityRepository>().Use<PublicityRepository>();
            For<IProductRepository>().Use<ProductRepository>();
            For<ICategoryRepository>().Use<CategoryRepository>();
            For<ISeasonRepository>().Use<SeasonRepository>();
        }
    }
}
