namespace Roshalonline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class today8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "Type");
        }
    }
}
