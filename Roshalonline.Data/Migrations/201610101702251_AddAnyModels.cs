namespace Roshalonline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnyModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Phonebooks",
                c => new
                    {
                        PhonebookID = c.Int(nullable: false, identity: true),
                        PhonebookCategory = c.String(),
                        PhonebookPhonenumber = c.String(),
                        PhonebookDescription = c.String(),
                    })
                .PrimaryKey(t => t.PhonebookID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductCategory = c.String(),
                        ProductDescription = c.String(),
                        ProductPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.Tarifs",
                c => new
                    {
                        TarifID = c.Int(nullable: false, identity: true),
                        TarifCategory = c.String(),
                        TarifName = c.String(),
                        TarifDescription = c.String(),
                        TarifPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TarifID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tarifs");
            DropTable("dbo.Products");
            DropTable("dbo.Phonebooks");
        }
    }
}
