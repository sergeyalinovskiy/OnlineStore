namespace SA.OnlineStore.Common
{
    #region Usings
    using SA.OnlineStore.Common.Logger;
    using StructureMap.Configuration.DSL;
    #endregion

    public class CommonDependencyRegistry :Registry
    {
        public CommonDependencyRegistry()
        {
            ForSingletonOf<ICommonLogger>().Use<CommonLogger>();
        }
    }
}
