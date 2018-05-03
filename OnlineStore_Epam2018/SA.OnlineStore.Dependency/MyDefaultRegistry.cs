namespace OnlineStore_Epam2018.DependencyResolution
{
    using SA.OnlineStore.Bussines.Components;
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Logger;
    using SA.OnlineStore.Dependency;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using System.Web.Mvc;

    public class MyDefaultRegistry : Registry
    {
        public MyDefaultRegistry()
        {
            ForSingletonOf<IProductService>().Use<ProductService>();
            ForSingletonOf<IOrderService>().Use<OrderService>();
            ForSingletonOf<ICommonLogger>().Use<CommonLogger>();
            ForSingletonOf<ICategoryService>().Use<CategoryService>();
            ForSingletonOf<ISeasonService>().Use<SeasonService>();
            ForSingletonOf<ISearchService>().Use<SearchSeervice>();
        }
    }
}