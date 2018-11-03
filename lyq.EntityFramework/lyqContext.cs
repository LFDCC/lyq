namespace lyq.EntityFramework
{
    using lyq.Entities;
    using lyq.EntityFramework.Migrations;
    using System.Data.Entity;
    using System.Reflection;

    public class lyqContext : DbContext
    {
        public lyqContext()
            : base("name=lyq")
        {

        }
        /// <summary>
        /// 静态的构造函数 只被调用一次
        /// </summary>
        static lyqContext()
        {
            //迁移到最后一个版本
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<lyqContext, Configuration>());
        }

        public virtual DbSet<UserEntity> UserEntities { get; set; }
        public virtual DbSet<PostEntity> PostEntities { get; set; }
        public virtual DbSet<MenuEntity> MenuEntities { get; set; }
        public virtual DbSet<RoleEntity> RoleEntities { get; set; }
        public virtual DbSet<ErrorLogEntity> LogEntities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //GetCallingAssembly 调用者程序集
            //GetExecutingAssembly 当前程序集
            Assembly assembly = Assembly.GetExecutingAssembly();
            //所有继承自EntityTypeConfiguration这个类的映射文件都会被自动注册进来
            modelBuilder.Configurations.AddFromAssembly(assembly);
        }
    }
}