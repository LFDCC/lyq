using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lyq.IEntities
{
    public interface IModifyAudited
    {
        int? ModifyUserId { get; set; }
        DateTime? ModifyTime { get; set; }
    }
}
