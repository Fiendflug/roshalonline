namespace Roshalonline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fluentAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsCategories",
                c => new
                    {
                        NewsCategoryID = c.Int(nullable: false, identity: true),
                        NewsCategoryName = c.String(),
                        NewsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NewsCategoryID);
            
            AddColumn("dbo.News", "NewsCategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.News", "NewsHeader", c => c.String());
            AlterColumn("dbo.News", "NewsAuthor", c => c.String());
            AlterColumn("dbo.News", "NewsPathToIcon", c => c.String());
            AlterColumn("dbo.News", "NotePathToPhotos", c => c.String());
            AlterColumn("dbo.News", "NewsBody", c => c.String());
            AlterColumn("dbo.Notes", "NoteHeader", c => c.String());
            AlterColumn("dbo.Notes", "NotePathToIcon", c => c.String());
            AlterColumn("dbo.Notes", "NotePathToPhotos", c => c.String());
            AlterColumn("dbo.Notes", "NoteBody", c => c.String());
            CreateIndex("dbo.News", "NewsCategoryID");
            AddForeignKey("dbo.News", "NewsCategoryID", "dbo.NewsCategories", "NewsCategoryID", cascadeDelete: true);
            DropColumn("dbo.News", "NewsCategory");
            DropColumn("dbo.Notes", "NoteCategory");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Phonebooks");
            DropTable("dbo.Products");
            DropTable("dbo.Tarifs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tarifs",
                c => new
                    {
                        TarifID = c.Int(nullable: false, identity: true),
                        TarifCategory = c.String(),
                        TarifName = c.String(),
                        TarifDescription = c.String(),
                        TarifPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TarifID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductCategory = c.String(),
                        ProductDescription = c.String(),
                        ProductPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.Phonebooks",
                c => new
                    {
                        PhonebookID = c.Int(nullable: false, identity: true),
                        PhonebookCategory = c.String(),
                        PhonebookPhonenumber = c.Int(nullable: false),
                        PhonebookDescription = c.String(),
                    })
                .PrimaryKey(t => t.PhonebookID);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        FeedbackID = c.Int(nullable: false, identity: true),
                        FeedbackCategory = c.String(),
                        FeedbackCreateDate = c.DateTime(nullable: false),
                        FeedbackHeader = c.String(),
                        FeedbackAuthorName = c.String(),
                        FeedbackAuthorAddress = c.String(),
                        FeedbackAuthorPhoneNumber = c.String(),
                        FeedbackBody = c.String(),
                    })
                .PrimaryKey(t => t.FeedbackID);
            
            AddColumn("dbo.Notes", "NoteCategory", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.News", "NewsCategory", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.News", "NewsCategoryID", "dbo.NewsCategories");
            DropIndex("dbo.News", new[] { "NewsCategoryID" });
            AlterColumn("dbo.Notes", "NoteBody", c => c.String(nullable: false, maxLength: 3000));
            AlterColumn("dbo.Notes", "NotePathToPhotos", c => c.String(maxLength: 3000));
            AlterColumn("dbo.Notes", "NotePathToIcon", c => c.String(maxLength: 300));
            AlterColumn("dbo.Notes", "NoteHeader", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.News", "NewsBody", c => c.String(nullable: false, maxLength: 3000));
            AlterColumn("dbo.News", "NotePathToPhotos", c => c.String(maxLength: 3000));
            AlterColumn("dbo.News", "NewsPathToIcon", c => c.String(maxLength: 300));
            AlterColumn("dbo.News", "NewsAuthor", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.News", "NewsHeader", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.News", "NewsCategoryID");
            DropTable("dbo.NewsCategories");
        }
    }
}
