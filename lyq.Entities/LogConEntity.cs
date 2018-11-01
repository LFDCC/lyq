using lyq.IEntities;
using System;

namespace lyq.Entities
{
    /// <summary>
    /// 登录日志
    /// </summary>
    public class LogConEntity : BaseEntity, ICreateEntity
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 客户端描述
        /// </summary>
        public string Client { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 操作耗时（ms）
        /// </summary>
        public long ElapsedTime { get; set; }
        /// <summary>
        /// 日志信息
        /// </summary>
        public string Message { get; set; }

        public int? CreateUserId { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
