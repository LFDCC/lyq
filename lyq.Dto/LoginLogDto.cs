using lyq.Entities;
using lyq.Infrastructure.Mapping;
using System;

namespace lyq.Dto
{
    [AutoMap(typeof(LoginLogEntity))]
    public class LoginLogDto : IMapper
    {
        public int Id { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 客户端名称
        /// </summary>
        public string ClientName { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string ClientIP { get; set; }
        /// <summary>
        /// 操作耗时（ms）
        /// </summary>
        public long ElapsedTime { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
