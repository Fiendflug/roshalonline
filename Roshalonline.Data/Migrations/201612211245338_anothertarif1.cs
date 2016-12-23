namespace Roshalonline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anothertarif1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PeriodicTarif", "Type");
            DropColumn("dbo.TelephonyMgTarif", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TelephonyMgTarif", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.PeriodicTarif", "Type", c => c.Int(nullable: false));
        }
    }
}
