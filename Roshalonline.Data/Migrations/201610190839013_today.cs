namespace Roshalonline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class today : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Header = c.String(),
                        Category = c.Int(nullable: false),
                        PathToIcon = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Body = c.String(),
                        ViewsCount = c.Long(nullable: false),
                        AuthorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.AuthorID, cascadeDelete: true)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PathToImages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        News_ID = c.Int(),
                        Note_ID = c.Int(),
                        Product_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.News", t => t.News_ID)
                .ForeignKey("dbo.Notes", t => t.Note_ID)
                .ForeignKey("dbo.Products", t => t.Product_ID)
                .Index(t => t.News_ID)
                .Index(t => t.Note_ID)
                .Index(t => t.Product_ID);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Category = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Header = c.String(),
                        ClientName = c.String(),
                        ClientAddress = c.String(),
                        ClientPhone = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Header = c.String(),
                        Category = c.Int(nullable: false),
                        PathToIcon = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Body = c.String(),
                        ViewsCount = c.Long(nullable: false),
                        AuthorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.AuthorID, cascadeDelete: true)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AuthorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.AuthorID, cascadeDelete: true)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.Tarifs",
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
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.AuthorID, cascadeDelete: true)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.DiscountPricesForTelephonyTarifs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DiscountValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tarif_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tarifs", t => t.Tarif_ID)
                .Index(t => t.Tarif_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiscountPricesForTelephonyTarifs", "Tarif_ID", "dbo.Tarifs");
            DropForeignKey("dbo.Tarifs", "AuthorID", "dbo.Users");
            DropForeignKey("dbo.PathToImages", "Product_ID", "dbo.Products");
            DropForeignKey("dbo.Products", "AuthorID", "dbo.Users");
            DropForeignKey("dbo.PathToImages", "Note_ID", "dbo.Notes");
            DropForeignKey("dbo.Notes", "AuthorID", "dbo.Users");
            DropForeignKey("dbo.PathToImages", "News_ID", "dbo.News");
            DropForeignKey("dbo.News", "AuthorID", "dbo.Users");
            DropIndex("dbo.DiscountPricesForTelephonyTarifs", new[] { "Tarif_ID" });
            DropIndex("dbo.Tarifs", new[] { "AuthorID" });
            DropIndex("dbo.Products", new[] { "AuthorID" });
            DropIndex("dbo.Notes", new[] { "AuthorID" });
            DropIndex("dbo.PathToImages", new[] { "Product_ID" });
            DropIndex("dbo.PathToImages", new[] { "Note_ID" });
            DropIndex("dbo.PathToImages", new[] { "News_ID" });
            DropIndex("dbo.News", new[] { "AuthorID" });
            DropTable("dbo.DiscountPricesForTelephonyTarifs");
            DropTable("dbo.Tarifs");
            DropTable("dbo.Products");
            DropTable("dbo.Notes");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.PathToImages");
            DropTable("dbo.Users");
            DropTable("dbo.News");
        }
    }
}
