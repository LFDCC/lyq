using lyq.Entities;
using lyq.Infrastructure.Mapping;
using System;

namespace lyq.Dto
{
    [AutoMap(typeof(LogEntity))]
    public class LogDto
    {
        public int Id { get; set; }
        /// <summary>
        /// Controller名称
        /// </summary>
        public string ControllerName { get; set; }
        /// <summary>
        /// Action名称
        /// </summary>
        public string ActionName { get; set; }
        /// <summary>
        /// Post/Get
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// 请求的地址
        /// </summary>
        public string RequestUrl { get; set; }
        /// <summary>
        /// Query参数
        /// </summary>
        public string Query { get; set; }
        /// <summary>
        /// Form参数
        /// </summary>
        public string Form { get; set; }
        /// <summary>
        /// 日志信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 1 Error 2 Warn 3 Info 4 Debug
        /// </summary>
        public int Level { get; set; }

        public int? CreateUserId { get; set; }

        public DateTime? CreateTime { get; set; } = DateTime.Now;
    }
}
