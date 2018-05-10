namespace OnlineStore_Epam2018.DependencyResolution
{
    using SA.OnlineStore.Bussines;
    using SA.OnlineStore.Bussines.Components;
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common;
    using SA.OnlineStore.Common.Logger;
    using SA.OnlineStore.DataAccess;
    using SA.OnlineStore.Dependency;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using System.Web.Mvc;

    public class MyDefaultRegistry : Registry
    {
       
        public MyDefaultRegistry()
        {
            //ForSingletonOf<ICommonLogger>().Use<CommonLogger>();

            Scan(m =>
            {
                m.AssemblyContainingType<DataAccessDependencyRegistry>();
                m.AssemblyContainingType<BussinesDependencyRegistry>();
                m.AssemblyContainingType<CommonDependencyRegistry>();
                

                m.WithDefaultConventions();
                m.LookForRegistries();
            });

            //For<IProductService>().Use<ProductService>();
            //For<IOrderService>().Use<OrderService>();
            //For<ICategoryService>().Use<CategoryService>();
            //For<ISeasonService>().Use<SeasonService>();
            //For<ISearchService>().Use<SearchSeervice>();
        }
    }
}