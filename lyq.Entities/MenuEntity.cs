namespace lyq.Entities
{
    public class MenuEntity : BaseEntity
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
        public int? ParentId { get; set; }
        /// <summary>
        /// null或0为通用权限
        /// </summary>
        public int? RoleId { get; set; }
    }
}
