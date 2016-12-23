namespace Roshalonline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anothertarif : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.InternetPeriodicTarif", newName: "PeriodicTarif");
            DropTable("dbo.TelephonyPeriodicTarif");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TelephonyPeriodicTarif",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.Int(nullable: false),
                        Audience = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AuthorID = c.Int(nullable: false),
                        AuthorName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            RenameTable(name: "dbo.PeriodicTarif", newName: "InternetPeriodicTarif");
        }
    }
}
