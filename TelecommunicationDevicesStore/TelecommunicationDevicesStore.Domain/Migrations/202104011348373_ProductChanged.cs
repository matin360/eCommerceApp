namespace TelecommunicationDevicesStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductChanged : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "ShorDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ShorDescription", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
