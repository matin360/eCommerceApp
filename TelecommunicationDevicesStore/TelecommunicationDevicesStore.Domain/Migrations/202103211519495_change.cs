namespace TelecommunicationDevicesStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarouselItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(nullable: false, maxLength: 50),
                        SlideNumber = c.String(nullable: false, maxLength: 50),
                        Heading = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 200),
                        TextLink = c.String(nullable: false, maxLength: 50),
                        ActionLink = c.String(nullable: false, maxLength: 50),
                        ControllerLink = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CarouselItems");
        }
    }
}
