namespace Roshalonline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fluentproperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "NewsPathToPhotos", c => c.String(maxLength: 100));
            AddColumn("dbo.Products", "ProductPathToPhotos", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.News", "NewsAuthor", c => c.String(nullable: false));
            AlterColumn("dbo.News", "NewsPathToIcon", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.News", "NewsBody", c => c.String(nullable: false, maxLength: 3000));
            AlterColumn("dbo.NewsCategories", "NewsCategoryName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Notes", "NoteHeader", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Notes", "NoteAuthor", c => c.String(nullable: false));
            AlterColumn("dbo.Notes", "NotePathToIcon", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Notes", "NotePathToPhotos", c => c.String(maxLength: 100));
            AlterColumn("dbo.Notes", "NoteBody", c => c.String(nullable: false, maxLength: 3000));
            AlterColumn("dbo.PhonebookCategories", "PhonebookCategoryName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Phonebooks", "PhonebookDescription", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.ProductCategories", "ProductCategoryName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Products", "ProductDescription", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.TarifCategories", "TarifCategoryName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Tarifs", "TarifName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Tarifs", "TarifDescription", c => c.String(nullable: false, maxLength: 1000));
            DropColumn("dbo.News", "NotePathToPhotos");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "NotePathToPhotos", c => c.String());
            AlterColumn("dbo.Tarifs", "TarifDescription", c => c.String());
            AlterColumn("dbo.Tarifs", "TarifName", c => c.String());
            AlterColumn("dbo.TarifCategories", "TarifCategoryName", c => c.String());
            AlterColumn("dbo.Products", "ProductDescription", c => c.String());
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            AlterColumn("dbo.ProductCategories", "ProductCategoryName", c => c.String());
            AlterColumn("dbo.Phonebooks", "PhonebookDescription", c => c.String());
            AlterColumn("dbo.PhonebookCategories", "PhonebookCategoryName", c => c.String());
            AlterColumn("dbo.Notes", "NoteBody", c => c.String());
            AlterColumn("dbo.Notes", "NotePathToPhotos", c => c.String());
            AlterColumn("dbo.Notes", "NotePathToIcon", c => c.String());
            AlterColumn("dbo.Notes", "NoteAuthor", c => c.String());
            AlterColumn("dbo.Notes", "NoteHeader", c => c.String());
            AlterColumn("dbo.NewsCategories", "NewsCategoryName", c => c.String());
            AlterColumn("dbo.News", "NewsBody", c => c.String());
            AlterColumn("dbo.News", "NewsPathToIcon", c => c.String());
            AlterColumn("dbo.News", "NewsAuthor", c => c.String());
            DropColumn("dbo.Products", "ProductPathToPhotos");
            DropColumn("dbo.News", "NewsPathToPhotos");
        }
    }
}
