namespace lyq.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addunique : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Sys_User", new[] { "UserName" });
            CreateIndex("dbo.Sys_User", "UserName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Sys_User", new[] { "UserName" });
            CreateIndex("dbo.Sys_User", "UserName");
        }
    }
}
