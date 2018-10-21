namespace lyq.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatelogentit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sys_Log", "ControllerName", c => c.String(maxLength: 50));
            AddColumn("dbo.Sys_Log", "ActionName", c => c.String(maxLength: 50));
            AddColumn("dbo.Sys_Log", "MethodType", c => c.String(maxLength: 10));
            AddColumn("dbo.Sys_Log", "RequestUrl", c => c.String(maxLength: 100));
            AddColumn("dbo.Sys_Log", "Message", c => c.String());
            AddColumn("dbo.Sys_Log", "LogType", c => c.Int(nullable: false));
            AlterColumn("dbo.Sys_Log", "Parameters", c => c.String());
            DropColumn("dbo.Sys_Log", "ServiceName");
            DropColumn("dbo.Sys_Log", "MethodName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sys_Log", "MethodName", c => c.String(maxLength: 50));
            AddColumn("dbo.Sys_Log", "ServiceName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Sys_Log", "Parameters", c => c.String(maxLength: 50));
            DropColumn("dbo.Sys_Log", "LogType");
            DropColumn("dbo.Sys_Log", "Message");
            DropColumn("dbo.Sys_Log", "RequestUrl");
            DropColumn("dbo.Sys_Log", "MethodType");
            DropColumn("dbo.Sys_Log", "ActionName");
            DropColumn("dbo.Sys_Log", "ControllerName");
        }
    }
}
