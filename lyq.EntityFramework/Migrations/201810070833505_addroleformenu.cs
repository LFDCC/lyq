namespace lyq.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addroleformenu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sys_Menu", "RoleId", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sys_Menu", "RoleId");
        }
    }
}
