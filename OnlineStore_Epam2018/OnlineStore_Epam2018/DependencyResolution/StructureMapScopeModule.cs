namespace OnlineStore_Epam2018.DependencyResolution {

    #region Usings
    using System.Web;

    using OnlineStore_Epam2018.App_Start;

    using StructureMap.Web.Pipeline;
    #endregion

    public class StructureMapScopeModule : IHttpModule {
        #region Public Methods and OperatorsD:\REPOSITORY\OnlineStore\OnlineStore_Epam2018\OnlineStore_Epam2018\Log.config.xml

        public void Dispose() {
        }

        public void Init(HttpApplication context) {
            context.BeginRequest += (sender, e) => StructuremapMvc.StructureMapDependencyScope.CreateNestedContainer();
            context.EndRequest += (sender, e) => {
                HttpContextLifecycle.DisposeAndClearAll();
                StructuremapMvc.StructureMapDependencyScope.DisposeNestedContainer();
            };
        }
        #endregion
    }
}