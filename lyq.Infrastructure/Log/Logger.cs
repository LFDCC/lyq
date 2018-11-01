using log4net;
using System;
using System.IO;
using System.Web;

namespace lyq.Infrastructure.Log
{
    public class Logger : ILogger
    {
        private ILog logger;
        public Logger()
        {
            logger = LogManager.GetLogger(GetType());
        }
        static Logger()
        {
            FileInfo configFile = new FileInfo(HttpContext.Current.Server.MapPath("/bin/Log/log4net.config"));
            log4net.Config.XmlConfigurator.Configure(configFile);
        }
        public void CreateLogger(Type type)
        {
            logger = LogManager.GetLogger(type);
        }
        public void Debug(object message)
        {
            logger.Debug(message);
        }
        public void Error(object message)
        {
            logger.Error(message);
        }
        public void Info(object message)
        {
            logger.Info(message);
        }
        public void Warn(object message)
        {
            logger.Warn(message);
        }
    }
}
