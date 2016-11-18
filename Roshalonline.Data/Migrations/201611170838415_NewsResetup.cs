namespace Roshalonline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsResetup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PathToImage", "News_ID", "dbo.News");
            DropForeignKey("dbo.PathToImage", "Note_ID", "dbo.Note");
            DropForeignKey("dbo.PathToImage", "Product_ID", "dbo.Product");
            DropIndex("dbo.PathToImage", new[] { "News_ID" });
            DropIndex("dbo.PathToImage", new[] { "Note_ID" });
            DropIndex("dbo.PathToImage", new[] { "Product_ID" });
            DropTable("dbo.PathToImage");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PathToImage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        News_ID = c.Int(),
                        Note_ID = c.Int(),
                        Product_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.PathToImage", "Product_ID");
            CreateIndex("dbo.PathToImage", "Note_ID");
            CreateIndex("dbo.PathToImage", "News_ID");
            AddForeignKey("dbo.PathToImage", "Product_ID", "dbo.Product", "ID");
            AddForeignKey("dbo.PathToImage", "Note_ID", "dbo.Note", "ID");
            AddForeignKey("dbo.PathToImage", "News_ID", "dbo.News", "ID");
        }
    }
}
