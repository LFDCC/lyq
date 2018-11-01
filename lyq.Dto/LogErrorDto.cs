using lyq.Entities;
using lyq.Infrastructure.Mapping;
using System;

namespace lyq.Dto
{
    [AutoMap(typeof(LogErrorEntity))]
    public class LogErrorDto : IMapper
    {
        public int Id { get; set; }
        /// <summary>
        /// 请求的地址
        /// </summary>
        public string RequestUrl { get; set; }
        /// <summary>
        /// 请求方式
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// Query参数
        /// </summary>
        public string Query { get; set; }
        /// <summary>
        /// Form参数
        /// </summary>
        public string Form { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 客户端描述
        /// </summary>
        public string Client { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { get; set; }

        public int? CreateUserId { get; set; }

        public DateTime? CreateTime { get; set; } = DateTime.Now;
    }
}
