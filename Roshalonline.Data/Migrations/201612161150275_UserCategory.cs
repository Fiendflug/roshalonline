namespace Roshalonline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "UserRole", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "UserRole");
        }
    }
}
