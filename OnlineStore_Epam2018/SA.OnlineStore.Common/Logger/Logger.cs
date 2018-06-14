namespace SA.OnlineStore.Common.Logger
{
    #region Usings
        using log4net;
        using log4net.Config;
    #endregion

    public static class Logger 
    {
        private static ILog log = LogManager.GetLogger("LOGGER");

        public static ILog Log
        {
            get { return log; }
        }

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    } 
}