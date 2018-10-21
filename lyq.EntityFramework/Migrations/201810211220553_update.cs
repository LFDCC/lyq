namespace lyq.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sys_Log", "Method", c => c.String(maxLength: 10));
            AddColumn("dbo.Sys_Log", "Query", c => c.String(maxLength: 200));
            AddColumn("dbo.Sys_Log", "Form", c => c.String(maxLength: 200));
            AddColumn("dbo.Sys_Log", "Level", c => c.Int(nullable: false));
            AlterColumn("dbo.Sys_Log", "RequestUrl", c => c.String(maxLength: 500));
            AlterColumn("dbo.Sys_Log", "Message", c => c.String(maxLength: 1000));
            DropColumn("dbo.Sys_Log", "MethodType");
            DropColumn("dbo.Sys_Log", "Parameters");
            DropColumn("dbo.Sys_Log", "LogType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sys_Log", "LogType", c => c.Int(nullable: false));
            AddColumn("dbo.Sys_Log", "Parameters", c => c.String());
            AddColumn("dbo.Sys_Log", "MethodType", c => c.String(maxLength: 10));
            AlterColumn("dbo.Sys_Log", "Message", c => c.String());
            AlterColumn("dbo.Sys_Log", "RequestUrl", c => c.String(maxLength: 100));
            DropColumn("dbo.Sys_Log", "Level");
            DropColumn("dbo.Sys_Log", "Form");
            DropColumn("dbo.Sys_Log", "Query");
            DropColumn("dbo.Sys_Log", "Method");
        }
    }
}
