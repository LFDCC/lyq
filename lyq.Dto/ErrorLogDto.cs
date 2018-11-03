using lyq.Entities;
using lyq.Infrastructure.Mapping;
using System;

namespace lyq.Dto
{
    [AutoMap(typeof(ErrorLogEntity))]
    public class ErrorLogDto : IMapper
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
        /// 客户端名称
        /// </summary>
        public string ClientName { get; set; }
        /// <summary>
        /// 客户端IP
        /// </summary>
        public string ClientIP { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
