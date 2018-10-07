using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lyq.IEntities
{
    /// <summary>
    /// 创建
    /// </summary>
    public interface ICreateAudited
    {
        long? CreateUserId { get; set; }
        DateTime? CreateTime { get; set; }
    }
}
