using System;

namespace lyq.IEntities
{
    /// <summary>
    /// 创建
    /// </summary>
    public interface ICreateAudited
    {
        int? CreateUserId { get; set; }
        DateTime? CreateTime { get; set; }
    }
}
