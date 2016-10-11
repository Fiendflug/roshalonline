namespace Roshalonline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class authoenote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "NoteAuthor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "NoteAuthor");
        }
    }
}
