namespace TelecommunicationDevicesStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersChanged : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 70),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 20),
                        UserRole = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CartProducts", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Customer_Id", c => c.Int());
            AddColumn("dbo.ContactMessages", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Feedbacks", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.CartProducts", "UserId");
            CreateIndex("dbo.Products", "Customer_Id");
            CreateIndex("dbo.ContactMessages", "UserId");
            CreateIndex("dbo.Feedbacks", "CustomerId");
            AddForeignKey("dbo.Products", "Customer_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.CartProducts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ContactMessages", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Feedbacks", "CustomerId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "CustomerId", "dbo.Users");
            DropForeignKey("dbo.ContactMessages", "UserId", "dbo.Users");
            DropForeignKey("dbo.CartProducts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "Customer_Id", "dbo.Users");
            DropIndex("dbo.Feedbacks", new[] { "CustomerId" });
            DropIndex("dbo.ContactMessages", new[] { "UserId" });
            DropIndex("dbo.Products", new[] { "Customer_Id" });
            DropIndex("dbo.CartProducts", new[] { "UserId" });
            DropColumn("dbo.Feedbacks", "CustomerId");
            DropColumn("dbo.ContactMessages", "UserId");
            DropColumn("dbo.Products", "Customer_Id");
            DropColumn("dbo.CartProducts", "UserId");
            DropTable("dbo.Users");
        }
    }
}
