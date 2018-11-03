using System;

namespace lyq.Entities
{
    /// <summary>
    /// 登录日志
    /// </summary>
    public class LoginLogEntity : BaseEntity
    {
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
        public DateTime CreateTime { get; set; }
    }
}
