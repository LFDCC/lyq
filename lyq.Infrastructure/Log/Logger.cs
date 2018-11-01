using log4net;
using lyq.Infrastructure.Ioc;
using System;

namespace lyq.Infrastructure.Log
{
    public class Logger : ILogger, IDependency
    {
        private ILog logger = LogManager.GetLogger(typeof(Logger));
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
