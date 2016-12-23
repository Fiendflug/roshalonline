namespace Roshalonline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tarifsEdit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InternetPeriodicTarif", "TarifTechnology", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InternetPeriodicTarif", "TarifTechnology");
        }
    }
}
