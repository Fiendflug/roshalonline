namespace Roshalonline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class today1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "User");
            RenameTable(name: "dbo.PathToImages", newName: "PathToImage");
            RenameTable(name: "dbo.Feedbacks", newName: "Feedback");
            RenameTable(name: "dbo.Notes", newName: "Note");
            RenameTable(name: "dbo.Products", newName: "Product");
            RenameTable(name: "dbo.Tarifs", newName: "Tarif");
            RenameTable(name: "dbo.DiscountPricesForTelephonyTarifs", newName: "DiscountPricesForTelephonyTarif");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.DiscountPricesForTelephonyTarif", newName: "DiscountPricesForTelephonyTarifs");
            RenameTable(name: "dbo.Tarif", newName: "Tarifs");
            RenameTable(name: "dbo.Product", newName: "Products");
            RenameTable(name: "dbo.Note", newName: "Notes");
            RenameTable(name: "dbo.Feedback", newName: "Feedbacks");
            RenameTable(name: "dbo.PathToImage", newName: "PathToImages");
            RenameTable(name: "dbo.User", newName: "Users");
        }
    }
}
