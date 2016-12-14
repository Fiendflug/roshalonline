namespace Roshalonline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class typenews : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "Type", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "Type", c => c.Int(nullable: false));
        }
    }
}
