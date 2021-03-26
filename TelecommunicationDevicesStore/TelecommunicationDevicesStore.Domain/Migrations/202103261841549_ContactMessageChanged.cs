namespace TelecommunicationDevicesStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactMessageChanged : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "Customers");
            DropForeignKey("dbo.ContactMessages", "UserId", "dbo.Users");
            DropIndex("dbo.ContactMessages", new[] { "UserId" });
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
            
            DropColumn("dbo.Customers", "UserRole");
            DropColumn("dbo.Customers", "Discriminator");
            DropColumn("dbo.ContactMessages", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactMessages", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Customers", "UserRole", c => c.Int());
            DropTable("dbo.SystemUsers");
            CreateIndex("dbo.ContactMessages", "UserId");
            AddForeignKey("dbo.ContactMessages", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Customers", newName: "Users");
        }
    }
}
