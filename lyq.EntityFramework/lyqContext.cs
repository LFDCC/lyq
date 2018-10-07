﻿namespace lyq.EntityFramework
{
    using lyq.EntityFramework.Migrations;
    using lyq.Entities;
    using System.Data.Entity;
    using System.Reflection;
    using lyq.EntityFramework.Mapping;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //获取实体映射
            Assembly assembly = Assembly.GetExecutingAssembly();
            modelBuilder.Configurations.AddFromAssembly(assembly);
        }
    }
}