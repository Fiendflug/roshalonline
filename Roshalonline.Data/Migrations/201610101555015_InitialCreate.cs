namespace Roshalonline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsID = c.Int(nullable: false, identity: true),
                        NewsHeader = c.String(),
                        NewsAuthor = c.String(),
                        NewsPathToIcon = c.String(),
                        NewsCreateDate = c.DateTime(nullable: false),
                        NewsBody = c.String(),
                        NewsViewsCount = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.NewsID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.News");
        }
    }
}
