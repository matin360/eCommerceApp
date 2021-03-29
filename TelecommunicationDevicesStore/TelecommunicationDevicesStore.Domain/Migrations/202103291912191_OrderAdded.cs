namespace TelecommunicationDevicesStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderAdded : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Customers", newName: "Users");
            DropForeignKey("dbo.CustomerProducts", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.CustomerProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.CustomerProducts", new[] { "Customer_Id" });
            DropIndex("dbo.CustomerProducts", new[] { "Product_Id" });
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Line1 = c.String(nullable: false, maxLength: 100),
                        Line2 = c.String(maxLength: 100),
                        Line3 = c.String(maxLength: 100),
                        City = c.String(nullable: false, maxLength: 100),
                        Country = c.String(nullable: false, maxLength: 100),
                        GiftWrap = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Products", "Order_Id", c => c.Int());
            AddColumn("dbo.Users", "UserRole", c => c.Int());
            AddColumn("dbo.Users", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Users", "Product_Id", c => c.Int());
            CreateIndex("dbo.Products", "Order_Id");
            CreateIndex("dbo.Users", "Product_Id");
            AddForeignKey("dbo.Users", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Products", "Order_Id", "dbo.Orders", "Id");
            DropTable("dbo.SystemUsers");
            DropTable("dbo.CustomerProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CustomerProducts",
                c => new
                    {
                        Customer_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_Id, t.Product_Id });
            
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
            
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Users", "Product_Id", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Product_Id" });
            DropIndex("dbo.Products", new[] { "Order_Id" });
            DropColumn("dbo.Users", "Product_Id");
            DropColumn("dbo.Users", "Discriminator");
            DropColumn("dbo.Users", "UserRole");
            DropColumn("dbo.Products", "Order_Id");
            DropTable("dbo.Orders");
            CreateIndex("dbo.CustomerProducts", "Product_Id");
            CreateIndex("dbo.CustomerProducts", "Customer_Id");
            AddForeignKey("dbo.CustomerProducts", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CustomerProducts", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Users", newName: "Customers");
        }
    }
}
