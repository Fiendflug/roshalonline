namespace Roshalonline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class author : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "AuthorName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "AuthorName");
        }
    }
}
