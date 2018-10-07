namespace lyq.EntityFramework.Migrations
{
    using lyq.Entities;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// 迁移配置类
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<lyqContext>
    {
        public Configuration()
        {
            //也可以手动迁移，再把生成的SQL拿到服务器上执行
            AutomaticMigrationsEnabled = true;//每次启动项目自动迁移
            //AutomaticMigrationDataLossAllowed = true;//允许自动迁移数据丢失，也可以使用add-migragion确认更改
        }

        protected override void Seed(lyqContext context)
        {
            //  迁移完会执行这里面的代码
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.MenuEntities.AddOrUpdate(t => t.Id, new MenuEntity[] {
                new MenuEntity{
                    Id=1,
                    Leave=1,
                    Title="主页",
                    Url="http://www.baidu.com",
                    Icon=""
                },
            });

            context.RoleEntities.AddOrUpdate(t => t.Id, new RoleEntity[] {
                new RoleEntity
                {
                    Id = 111,
                    RoleName = "超级管理员"
                },
                new RoleEntity
                {
                    Id = 222,
                    RoleName = "普通管理员"
                },
                new RoleEntity
                {
                    Id = 333,
                    RoleName = "普通用户"
                }
            });

            context.UserEntities.AddOrUpdate(t => t.UserName, new UserEntity
            {
                UserName = "admin",
                RealName = "拉风的CC",
                Phone = "18105207689",
                Password = "000000",
                Email = "1584329729@qq.com",
                RoleId = 111
            });



            context.SaveChanges();
        }
    }
}
