using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lyq.Infrastructure.Extension
{
    public static class CollectionExt
    {
        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            if (source != null)
            {
                return source.Count <= 0;
            }
            return true;
        }
    }
}
