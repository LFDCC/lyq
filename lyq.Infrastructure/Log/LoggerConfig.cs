using System.IO;
using System.Web;

namespace lyq.Infrastructure.Log
{
    public class LoggerConfig
    {
        /// <summary>
        /// 注册Log4net
        /// </summary>
        /// <param name="configPath">配置文件路径</param>
        public static void RegisterLog4net(string configPath)
        {
            FileInfo configFile = new FileInfo(HttpContext.Current.Server.MapPath(configPath));
            log4net.Config.XmlConfigurator.Configure(configFile);
        }
    }
}
