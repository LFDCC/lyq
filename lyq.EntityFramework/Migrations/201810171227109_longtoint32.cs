namespace lyq.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class longtoint32 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sys_Post", "CreateUserId", "dbo.Sys_User");
            DropForeignKey("dbo.Sys_User", "RoleId", "dbo.Sys_Role");
            DropIndex("dbo.Sys_Post", new[] { "CreateUserId" });
            DropIndex("dbo.Sys_User", new[] { "RoleId" });
            DropPrimaryKey("dbo.Sys_Menu");
            DropPrimaryKey("dbo.Sys_Post");
            DropPrimaryKey("dbo.Sys_User");
            DropPrimaryKey("dbo.Sys_Role");
            DropPrimaryKey("dbo.Sys_Log");
            AlterColumn("dbo.Sys_Menu", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Sys_Menu", "ParentId", c => c.Int());
            AlterColumn("dbo.Sys_Menu", "RoleId", c => c.Int());
            AlterColumn("dbo.Sys_Post", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Sys_Post", "CreateUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Sys_User", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Sys_User", "RoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.Sys_User", "DeleteUserId", c => c.Int());
            AlterColumn("dbo.Sys_Role", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Sys_Log", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Sys_Log", "CreateUserId", c => c.Int());
            AddPrimaryKey("dbo.Sys_Menu", "Id");
            AddPrimaryKey("dbo.Sys_Post", "Id");
            AddPrimaryKey("dbo.Sys_User", "Id");
            AddPrimaryKey("dbo.Sys_Role", "Id");
            AddPrimaryKey("dbo.Sys_Log", "Id");
            CreateIndex("dbo.Sys_Post", "CreateUserId");
            CreateIndex("dbo.Sys_User", "RoleId");
            AddForeignKey("dbo.Sys_Post", "CreateUserId", "dbo.Sys_User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sys_User", "RoleId", "dbo.Sys_Role", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sys_User", "RoleId", "dbo.Sys_Role");
            DropForeignKey("dbo.Sys_Post", "CreateUserId", "dbo.Sys_User");
            DropIndex("dbo.Sys_User", new[] { "RoleId" });
            DropIndex("dbo.Sys_Post", new[] { "CreateUserId" });
            DropPrimaryKey("dbo.Sys_Log");
            DropPrimaryKey("dbo.Sys_Role");
            DropPrimaryKey("dbo.Sys_User");
            DropPrimaryKey("dbo.Sys_Post");
            DropPrimaryKey("dbo.Sys_Menu");
            AlterColumn("dbo.Sys_Log", "CreateUserId", c => c.Long());
            AlterColumn("dbo.Sys_Log", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Sys_Role", "Id", c => c.Long(nullable: false));
            AlterColumn("dbo.Sys_User", "DeleteUserId", c => c.Long());
            AlterColumn("dbo.Sys_User", "RoleId", c => c.Long(nullable: false));
            AlterColumn("dbo.Sys_User", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Sys_Post", "CreateUserId", c => c.Long(nullable: false));
            AlterColumn("dbo.Sys_Post", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Sys_Menu", "RoleId", c => c.Long());
            AlterColumn("dbo.Sys_Menu", "ParentId", c => c.Long());
            AlterColumn("dbo.Sys_Menu", "Id", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Sys_Log", "Id");
            AddPrimaryKey("dbo.Sys_Role", "Id");
            AddPrimaryKey("dbo.Sys_User", "Id");
            AddPrimaryKey("dbo.Sys_Post", "Id");
            AddPrimaryKey("dbo.Sys_Menu", "Id");
            CreateIndex("dbo.Sys_User", "RoleId");
            CreateIndex("dbo.Sys_Post", "CreateUserId");
            AddForeignKey("dbo.Sys_User", "RoleId", "dbo.Sys_Role", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sys_Post", "CreateUserId", "dbo.Sys_User", "Id", cascadeDelete: true);
        }
    }
}
