namespace Roshalonline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1155 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "PathToCover", c => c.String());
            AlterColumn("dbo.News", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "Type", c => c.String());
            DropColumn("dbo.News", "PathToCover");
        }
    }
}
