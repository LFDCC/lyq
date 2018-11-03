namespace lyq.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateLog : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Sys_Log_Error");
            DropTable("dbo.Sys_Log_Connection");
            DropTable("dbo.Sys_Log_Operation");

            CreateTable(
                "dbo.Sys_Log_Error",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestUrl = c.String(maxLength: 500),
                        Method = c.String(maxLength: 10),
                        Query = c.String(),
                        Form = c.String(),
                        Message = c.String(),
                        ClientName = c.String(maxLength: 200),
                        ClientIP = c.String(maxLength: 20),
                        CreateUserId = c.Int(),
                        CreateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sys_Log_Login",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginName = c.String(maxLength: 50),
                        ClientName = c.String(maxLength: 100),
                        ClientIP = c.String(maxLength: 20),
                        ElapsedTime = c.Long(nullable: false),
                        CreateUserId = c.Int(),
                        CreateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sys_Log_Action",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestUrl = c.String(maxLength: 500),
                        Method = c.String(maxLength: 10),
                        Query = c.String(),
                        Form = c.String(),
                        ClientName = c.String(maxLength: 100),
                        ClientIP = c.String(maxLength: 20),
                        ElapsedTime = c.Long(nullable: false),
                        CreateUserId = c.Int(),
                        CreateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Sys_Log_Operation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestUrl = c.String(maxLength: 500),
                        Method = c.String(maxLength: 10),
                        Query = c.String(),
                        Form = c.String(),
                        Client = c.String(maxLength: 100),
                        IP = c.String(maxLength: 20),
                        ElapsedTime = c.Long(nullable: false),
                        Message = c.String(),
                        CreateUserId = c.Int(),
                        CreateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sys_Log_Connection",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginName = c.String(maxLength: 50),
                        Client = c.String(maxLength: 100),
                        IP = c.String(maxLength: 20),
                        ElapsedTime = c.Long(nullable: false),
                        Message = c.String(),
                        CreateUserId = c.Int(),
                        CreateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sys_Log_Error",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestUrl = c.String(maxLength: 500),
                        Method = c.String(maxLength: 10),
                        Query = c.String(),
                        Form = c.String(),
                        Message = c.String(),
                        Client = c.String(maxLength: 200),
                        IP = c.String(maxLength: 20),
                        CreateUserId = c.Int(),
                        CreateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Sys_Log_Action");
            DropTable("dbo.Sys_Log_Login");
            DropTable("dbo.Sys_Log_Error");
        }
    }
}
