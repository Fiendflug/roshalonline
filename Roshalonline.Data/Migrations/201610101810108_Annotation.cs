namespace Roshalonline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Annotation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "NewsCategory", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.News", "NotePathToPhotos", c => c.String(maxLength: 3000));
            AddColumn("dbo.Notes", "NotePathToPhotos", c => c.String(maxLength: 3000));
            AlterColumn("dbo.News", "NewsHeader", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.News", "NewsAuthor", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.News", "NewsPathToIcon", c => c.String(maxLength: 300));
            AlterColumn("dbo.News", "NewsBody", c => c.String(nullable: false, maxLength: 3000));
            AlterColumn("dbo.Notes", "NoteCategory", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Notes", "NoteHeader", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Notes", "NotePathToIcon", c => c.String(maxLength: 300));
            AlterColumn("dbo.Notes", "NoteBody", c => c.String(nullable: false, maxLength: 3000));
            AlterColumn("dbo.Phonebooks", "PhonebookPhonenumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Phonebooks", "PhonebookPhonenumber", c => c.String());
            AlterColumn("dbo.Notes", "NoteBody", c => c.String());
            AlterColumn("dbo.Notes", "NotePathToIcon", c => c.String());
            AlterColumn("dbo.Notes", "NoteHeader", c => c.String());
            AlterColumn("dbo.Notes", "NoteCategory", c => c.String());
            AlterColumn("dbo.News", "NewsBody", c => c.String());
            AlterColumn("dbo.News", "NewsPathToIcon", c => c.String());
            AlterColumn("dbo.News", "NewsAuthor", c => c.String());
            AlterColumn("dbo.News", "NewsHeader", c => c.String());
            DropColumn("dbo.Notes", "NotePathToPhotos");
            DropColumn("dbo.News", "NotePathToPhotos");
            DropColumn("dbo.News", "NewsCategory");
        }
    }
}
