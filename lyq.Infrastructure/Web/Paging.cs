namespace lyq.Infrastructure.Web
{
    public class Paging
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
        public int pageNum
        {
            get
            {
                return (total + pageSize - 1) / pageSize;
            }
        }

        /// <summary>
        /// 结果集合
        /// </summary>
        public object data { get; set; }
    }
}
