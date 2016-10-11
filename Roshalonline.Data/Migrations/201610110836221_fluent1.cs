namespace Roshalonline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fluent1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.News", name: "NewsCategoryID", newName: "CategoryID");
            RenameIndex(table: "dbo.News", name: "IX_NewsCategoryID", newName: "IX_CategoryID");
            DropColumn("dbo.NewsCategories", "NewsID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewsCategories", "NewsID", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.News", name: "IX_CategoryID", newName: "IX_NewsCategoryID");
            RenameColumn(table: "dbo.News", name: "CategoryID", newName: "NewsCategoryID");
        }
    }
}
