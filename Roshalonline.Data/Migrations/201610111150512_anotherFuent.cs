namespace Roshalonline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotherFuent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "NewsHeader", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "NewsHeader", c => c.String());
        }
    }
}
