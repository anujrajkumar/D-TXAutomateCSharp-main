using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace GenericFrameworkComponent.Utilities
{
    public class LogUtil
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

      public static void logInit()
        {
            BasicConfigurator.Configure();
            XmlConfigurator.Configure(new FileInfo(FileFolderUtil.log4netConfigFileCompletePath()));
        }

      public static void DebugLog(string Message)
        {
            log.Debug(Message);
           
        }

        public static void infoLog(string Message)
        {
            log.Info(Message);
           
        }

        public static void WarnLog(string Message)
        {
            log.Warn(Message);
           
        }

        public static void ErrorLog(string Message)
        {
            log.Error(Message);
           
        }

        public static void FatalLog(string Message)
        {
            log.Fatal(Message);
        }
    }
}