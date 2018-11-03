namespace lyq.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update20181103 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sys_Log_Login", "IsSuccess", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Sys_Log_Error", "CreateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Sys_Post", "CreateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Sys_Log_Login", "CreateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Sys_Log_Action", "CreateUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Sys_Log_Action", "CreateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Sys_Log_Error", "CreateUserId");
            DropColumn("dbo.Sys_Log_Login", "CreateUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sys_Log_Login", "CreateUserId", c => c.Int());
            AddColumn("dbo.Sys_Log_Error", "CreateUserId", c => c.Int());
            AlterColumn("dbo.Sys_Log_Action", "CreateTime", c => c.DateTime());
            AlterColumn("dbo.Sys_Log_Action", "CreateUserId", c => c.Int());
            AlterColumn("dbo.Sys_Log_Login", "CreateTime", c => c.DateTime());
            AlterColumn("dbo.Sys_Post", "CreateTime", c => c.DateTime());
            AlterColumn("dbo.Sys_Log_Error", "CreateTime", c => c.DateTime());
            DropColumn("dbo.Sys_Log_Login", "IsSuccess");
        }
    }
}
