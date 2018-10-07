using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lyq.IEntities
{
    /// <summary>
    /// 删除/禁用
    /// </summary>
    public interface IDeleteAudited
    {
        long? DeleteUserId { get; set; }
        bool? IsDelete { get; set; }
        DateTime? DeleteTime { get; set; }
    }
}
