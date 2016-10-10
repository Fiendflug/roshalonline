namespace Roshalonline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Notes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        NoteID = c.Int(nullable: false, identity: true),
                        NoteCategory = c.String(),
                        NoteHeader = c.String(),
                        NotePathToIcon = c.String(),
                        NoteCreateDate = c.DateTime(nullable: false),
                        NoteBody = c.String(),
                        NoteViewsCount = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.NoteID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notes");
        }
    }
}
