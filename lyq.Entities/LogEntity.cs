using lyq.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lyq.Entities
{
    public class LogEntity : BaseEntity, ICreateAudited
    {
        /// <summary>
        /// service名称
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// 方法action名称
        /// </summary>
        public string MethodName { get; set; }
        /// <summary>
        /// 请求参数
        /// </summary>
        public string Parameters { get; set; }

        public long? CreateUserId { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
