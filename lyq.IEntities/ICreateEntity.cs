using System;

namespace lyq.IEntities
{
    /// <summary>
    /// 创建
    /// </summary>
    public interface ICreateEntity
    {
        int? CreateUserId { get; set; }
        DateTime? CreateTime { get; set; }
    }
}
