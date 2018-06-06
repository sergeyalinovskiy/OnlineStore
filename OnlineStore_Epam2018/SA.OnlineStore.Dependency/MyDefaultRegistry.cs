namespace OnlineStore_Epam2018.DependencyResolution
{
    #region Usings
    using SA.OnlineStore.Bussines;
    using SA.OnlineStore.Common;
    using SA.OnlineStore.DataAccess;
    using StructureMap.Configuration.DSL;
    #endregion

    public class MyDefaultRegistry : Registry
    {
        public MyDefaultRegistry()
        {
            Scan(m =>
            {
                m.AssemblyContainingType<DataAccessDependencyRegistry>();
                m.AssemblyContainingType<BussinesDependencyRegistry>();
                m.AssemblyContainingType<CommonDependencyRegistry>();
                m.WithDefaultConventions();
                m.LookForRegistries();
            });
        }
    }
}