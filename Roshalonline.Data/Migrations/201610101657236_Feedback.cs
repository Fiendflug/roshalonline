namespace Roshalonline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Feedback : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        FeedbackID = c.Int(nullable: false, identity: true),
                        FeedbackCategory = c.String(),
                        FeedbackCreateDate = c.DateTime(nullable: false),
                        FeedbackHeader = c.String(),
                        FeedbackAuthorName = c.String(),
                        FeedbackAuthorAddress = c.String(),
                        FeedbackAuthorPhoneNumber = c.String(),
                        FeedbackBody = c.String(),
                    })
                .PrimaryKey(t => t.FeedbackID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Feedbacks");
        }
    }
}
