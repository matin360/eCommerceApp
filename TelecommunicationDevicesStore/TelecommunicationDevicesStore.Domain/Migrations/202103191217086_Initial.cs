namespace TelecommunicationDevicesStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ShorDescription = c.String(nullable: false, maxLength: 100),
                        MetaDescription = c.String(nullable: false, maxLength: 500),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImagePath = c.String(nullable: false),
                        StockCount = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        CartProducts_Id = c.Int(),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.CartProducts", t => t.CartProducts_Id)
                .ForeignKey("dbo.Users", t => t.Customer_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.CartProducts_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.ContactMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 70),
                        UserEmail = c.String(nullable: false),
                        UserPhoneNumber = c.String(nullable: false),
                        Message = c.String(nullable: false, maxLength: 300),
                        SubmittedDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 70),
                        Message = c.String(nullable: false, maxLength: 300),
                        WrittenDate = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        ControllerName = c.String(nullable: false, maxLength: 30),
                        ActionName = c.String(nullable: false, maxLength: 30),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "CustomerId", "dbo.Users");
            DropForeignKey("dbo.ContactMessages", "UserId", "dbo.Users");
            DropForeignKey("dbo.CartProducts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "Customer_Id", "dbo.Users");
            DropForeignKey("dbo.Products", "CartProducts_Id", "dbo.CartProducts");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Feedbacks", new[] { "CustomerId" });
            DropIndex("dbo.ContactMessages", new[] { "UserId" });
            DropIndex("dbo.Products", new[] { "Customer_Id" });
            DropIndex("dbo.Products", new[] { "CartProducts_Id" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.CartProducts", new[] { "UserId" });
            DropTable("dbo.Services");
            DropTable("dbo.Menus");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.ContactMessages");
            DropTable("dbo.Users");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.CartProducts");
        }
    }
}
