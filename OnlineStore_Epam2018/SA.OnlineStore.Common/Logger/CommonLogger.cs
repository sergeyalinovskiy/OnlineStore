namespace SA.OnlineStore.Common.Logger
{
    #region Usings
        using log4net;
        using System;
        using System.IO;
        using System.Reflection;
    #endregion

    public class CommonLogger : ICommonLogger
    {
        private readonly ILog _log;
        public CommonLogger()
        {
            var path = new DirectoryInfo(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath)).FullName + @"\Log.config";
            log4net.Config.XmlConfigurator.Configure(new FileInfo(path));
            _log = log4net.LogManager.GetLogger("LOGGER");
        }
        public void Info(string info)
        {
            _log.Info(info);
        }
    }
}