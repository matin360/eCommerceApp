namespace TelecommunicationDevicesStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderModified : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "Customers");
            CreateTable(
                "dbo.SystemUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserRole = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 70),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Customers", "UserRole");
            DropColumn("dbo.Customers", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Customers", "UserRole", c => c.Int());
            DropColumn("dbo.Orders", "TotalPrice");
            DropTable("dbo.SystemUsers");
            RenameTable(name: "dbo.Customers", newName: "Users");
        }
    }
}
