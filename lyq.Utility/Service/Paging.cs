using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lyq.Utility.Service
{
    public class Paging<TElement>
    {
        /// <summary>
        /// 总条数
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int pageIndex { get; set; }

        /// <summary>
        /// 每页条数
        /// </summary>
        public int pageSize { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        private int pageNum
        {
            get
            {
                return (total + pageSize - 1) / pageSize;
            }
        }

        /// <summary>
        /// 结果集合
        /// </summary>
        public List<TElement> result { get; set; }

    }
}
