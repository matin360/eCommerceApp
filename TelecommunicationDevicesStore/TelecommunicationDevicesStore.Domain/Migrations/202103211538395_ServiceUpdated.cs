namespace TelecommunicationDevicesStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "ImagePath", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "ImagePath");
        }
    }
}
