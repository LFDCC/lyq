using System.Net;
using System.Net.Sockets;
using System.Web;

namespace lyq.Infrastructure.Network
{
    public class Net
    {
        #region Ip(获取Ip)
        /// <summary>
        /// 获取IP。
        /// </summary>
        public static string Ip
        {
            get
            {
                var result = string.Empty;
                if (HttpContext.Current != null)
                {
                    result = GetWebClientIp();
                }
                if (string.IsNullOrEmpty(result))
                {
                    result = GetLanIp();
                }
                return result;
            }
        }

        /// <summary>
        /// 获取Web客户端IP。
        /// </summary>
        private static string GetWebClientIp()
        {
            var ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            foreach (var hostAddress in Dns.GetHostAddresses(ip))
            {
                if (hostAddress.AddressFamily == AddressFamily.InterNetwork)
                    return hostAddress.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取局域网IP。
        /// </summary>
        private static string GetLanIp()
        {
            foreach (var hostAddress in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (hostAddress.AddressFamily == AddressFamily.InterNetwork)
                    return hostAddress.ToString();
            }
            return string.Empty;
        }
        

        #endregion
    }
}
