using lyq.IEntities;
using System;

namespace lyq.Entities
{
    public class PostEntity :BaseEntity,ICreateAudited
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 发送的邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public virtual UserEntity User { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public long? CreateUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}
