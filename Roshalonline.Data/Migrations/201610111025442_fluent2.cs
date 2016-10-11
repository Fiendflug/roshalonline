namespace Roshalonline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fluent2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhonebookCategories",
                c => new
                    {
                        PhonebookCategoryID = c.Int(nullable: false, identity: true),
                        PhonebookCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.PhonebookCategoryID);
            
            CreateTable(
                "dbo.Phonebooks",
                c => new
                    {
                        PhonebookID = c.Int(nullable: false, identity: true),
                        PhonebookPhonenumber = c.Int(nullable: false),
                        PhonebookDescription = c.String(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhonebookID)
                .ForeignKey("dbo.PhonebookCategories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ProductCategoryID = c.Int(nullable: false, identity: true),
                        ProductCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.ProductCategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductDescription = c.String(),
                        ProductPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.ProductCategories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.TarifCategories",
                c => new
                    {
                        TarifCategoryID = c.Int(nullable: false, identity: true),
                        TarifCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.TarifCategoryID);
            
            CreateTable(
                "dbo.Tarifs",
                c => new
                    {
                        TarifID = c.Int(nullable: false, identity: true),
                        TarifName = c.String(),
                        TarifDescription = c.String(),
                        TarifPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TarifID)
                .ForeignKey("dbo.TarifCategories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarifs", "CategoryID", "dbo.TarifCategories");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.ProductCategories");
            DropForeignKey("dbo.Phonebooks", "CategoryID", "dbo.PhonebookCategories");
            DropIndex("dbo.Tarifs", new[] { "CategoryID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Phonebooks", new[] { "CategoryID" });
            DropTable("dbo.Tarifs");
            DropTable("dbo.TarifCategories");
            DropTable("dbo.Products");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Phonebooks");
            DropTable("dbo.PhonebookCategories");
        }
    }
}
