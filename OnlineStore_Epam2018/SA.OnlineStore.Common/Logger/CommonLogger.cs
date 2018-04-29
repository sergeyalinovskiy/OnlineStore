﻿using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Common.Logger
{
    public class CommonLogger : ICommonLogger
    {
        private readonly ILog _log;
        public CommonLogger()
        {
            //string name= @"\Log.config";
            //string str = Environment.CurrentDirectory;

            var path = new DirectoryInfo(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath)).FullName + @"\Log.config";

            //FileInfo file = new FileInfo(path);

           // log4net.Config.XmlConfigurator.Configure(new FileInfo("D:\\REPOSITORY\\OnlineStore\\OnlineStore_Epam2018\\SA.OnlineStore.Common\\Log.config"));
            log4net.Config.XmlConfigurator.Configure(new FileInfo(path));
            _log = log4net.LogManager.GetLogger("LOGGER");
        }
        public void Info(string info)
        {
           // Logger.InitLogger();
            //Logger.Log.Info(info);
            _log.Info(info);
        }
    }
}
