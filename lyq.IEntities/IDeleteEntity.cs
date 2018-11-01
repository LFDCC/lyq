using System;

namespace lyq.IEntities
{
    /// <summary>
    /// 删除/禁用
    /// </summary>
    public interface IDeleteEntity
    {
        int? DeleteUserId { get; set; }
        bool? IsDelete { get; set; }
        DateTime? DeleteTime { get; set; }
    }
}
