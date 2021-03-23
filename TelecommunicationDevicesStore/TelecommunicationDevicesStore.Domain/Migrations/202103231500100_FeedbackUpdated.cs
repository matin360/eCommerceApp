namespace TelecommunicationDevicesStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedbackUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feedbacks", "SlideNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Feedbacks", "SlideNumber");
        }
    }
}
