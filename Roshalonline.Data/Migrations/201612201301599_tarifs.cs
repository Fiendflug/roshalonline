namespace Roshalonline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tarifs : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tarif", newName: "InternetPeriodicTarif");
            DropForeignKey("dbo.Tarif", "AuthorID", "dbo.User");
            DropForeignKey("dbo.DiscountPricesForTelephonyTarif", "Tarif_ID", "dbo.Tarif");
            DropIndex("dbo.InternetPeriodicTarif", new[] { "AuthorID" });
            DropIndex("dbo.DiscountPricesForTelephonyTarif", new[] { "Tarif_ID" });
            CreateTable(
                "dbo.TelephonyMgTarif",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.Int(nullable: false),
                        Audience = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        DestinationName = c.String(),
                        CodeZone = c.String(),
                        FullParice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TimeDiscountPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HolidayDiscountPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AuthorID = c.Int(nullable: false),
                        AuthorName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
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
            
            AddColumn("dbo.InternetPeriodicTarif", "AuthorName", c => c.String());
            DropTable("dbo.DiscountPricesForTelephonyTarif");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DiscountPricesForTelephonyTarif",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DiscountValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tarif_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.InternetPeriodicTarif", "AuthorName");
            DropTable("dbo.TelephonyPeriodicTarif");
            DropTable("dbo.TelephonyMgTarif");
            CreateIndex("dbo.DiscountPricesForTelephonyTarif", "Tarif_ID");
            CreateIndex("dbo.InternetPeriodicTarif", "AuthorID");
            AddForeignKey("dbo.DiscountPricesForTelephonyTarif", "Tarif_ID", "dbo.Tarif", "ID");
            AddForeignKey("dbo.Tarif", "AuthorID", "dbo.User", "ID", cascadeDelete: true);
            RenameTable(name: "dbo.InternetPeriodicTarif", newName: "Tarif");
        }
    }
}
