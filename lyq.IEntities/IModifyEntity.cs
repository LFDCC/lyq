using System;

namespace lyq.IEntities
{
    public interface IModifyEntity
    {
        int? ModifyUserId { get; set; }
        DateTime? ModifyTime { get; set; }
    }
}
