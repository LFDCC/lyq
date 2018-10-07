namespace lyq.Entities
{
    public class MenuEntity :BaseEntity
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        public int Leave { get; set; }
        /// <summary>
        /// 父级
        /// </summary>
        public long? ParentId { get; set; }
    }
}
