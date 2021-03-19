namespace TelecommunicationDevicesStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUsers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Customer_Id", "dbo.Users");
            DropForeignKey("dbo.CartProducts", "UserId", "dbo.Users");
            DropForeignKey("dbo.ContactMessages", "UserId", "dbo.Users");
            DropForeignKey("dbo.Feedbacks", "CustomerId", "dbo.Users");
            DropIndex("dbo.CartProducts", new[] { "UserId" });
            DropIndex("dbo.Products", new[] { "Customer_Id" });
            DropIndex("dbo.ContactMessages", new[] { "UserId" });
            DropIndex("dbo.Feedbacks", new[] { "CustomerId" });
            DropColumn("dbo.CartProducts", "UserId");
            DropColumn("dbo.Products", "Customer_Id");
            DropColumn("dbo.ContactMessages", "UserId");
            DropColumn("dbo.Feedbacks", "CustomerId");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 70),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(maxLength: 20),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Feedbacks", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.ContactMessages", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Customer_Id", c => c.Int());
            AddColumn("dbo.CartProducts", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Feedbacks", "CustomerId");
            CreateIndex("dbo.ContactMessages", "UserId");
            CreateIndex("dbo.Products", "Customer_Id");
            CreateIndex("dbo.CartProducts", "UserId");
            AddForeignKey("dbo.Feedbacks", "CustomerId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ContactMessages", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CartProducts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "Customer_Id", "dbo.Users", "Id");
        }
    }
}
