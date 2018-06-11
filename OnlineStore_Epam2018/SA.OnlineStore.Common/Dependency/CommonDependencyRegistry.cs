namespace SA.OnlineStore.Common
{
    using SA.OnlineStore.Common.Cache;
    #region Usings
    using SA.OnlineStore.Common.Logger;
    using StructureMap.Configuration.DSL;
    #endregion

    public class CommonDependencyRegistry :Registry
    {
        public CommonDependencyRegistry()
        {
            ForSingletonOf<ICommonLogger>().Use<CommonLogger>();
            ForSingletonOf<IStoreCache>().Use<StoreCache>();
        }
    }
}