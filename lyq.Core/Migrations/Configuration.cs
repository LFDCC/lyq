namespace lyq.EntityFramework.Migrations
{
    using lyq.Entities;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Ǩ��������
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<lyqContext>
    {
        public Configuration()
        {
            //Ҳ�����ֶ�Ǩ�ƣ��ٰ����ɵ�SQL�õ���������ִ��
            AutomaticMigrationsEnabled = true;//ÿ��������Ŀ�Զ�Ǩ��
            //AutomaticMigrationDataLossAllowed = true;//�����Զ�Ǩ�����ݶ�ʧ��Ҳ����ʹ��add-migragionȷ�ϸ���
        }

        protected override void Seed(lyqContext context)
        {
            //  Ǩ�����ִ��������Ĵ���
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.MenuEntities.AddOrUpdate(t => t.Id, new MenuEntity[] {
                new MenuEntity{
                    Id=1,
                    Leave=1,
                    Title="��ҳ",
                    Url="http://www.baidu.com",
                    Icon=""
                },
            });

            context.RoleEntities.AddOrUpdate(t => t.Id, new RoleEntity[] {
                new RoleEntity
                {
                    Id = 111,
                    RoleName = "��������Ա"
                },
                new RoleEntity
                {
                    Id = 222,
                    RoleName = "��ͨ����Ա"
                },
                new RoleEntity
                {
                    Id = 333,
                    RoleName = "��ͨ�û�"
                }
            });

            context.UserEntities.AddOrUpdate(t => t.UserName, new UserEntity
            {
                UserName = "admin",
                RealName = "�����CC",
                Phone = "18105207689",
                Password = "000000",
                Email = "1584329729@qq.com",
                RoleId = 111
            });



            context.SaveChanges();
        }
    }
}
