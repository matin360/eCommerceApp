namespace TelecommunicationDevicesStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CartProducts_Id", "dbo.CartProducts");
            DropForeignKey("dbo.Products", "Customer_Id", "dbo.Users");
            DropIndex("dbo.Products", new[] { "CartProducts_Id" });
            DropIndex("dbo.Products", new[] { "Customer_Id" });
            CreateTable(
                "dbo.ProductCartProducts",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        CartProducts_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.CartProducts_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.CartProducts", t => t.CartProducts_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.CartProducts_Id);
            
            CreateTable(
                "dbo.CustomerProducts",
                c => new
                    {
                        Customer_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_Id, t.Product_Id })
                .ForeignKey("dbo.Users", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Product_Id);
            
            DropColumn("dbo.Products", "CartProducts_Id");
            DropColumn("dbo.Products", "Customer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Customer_Id", c => c.Int());
            AddColumn("dbo.Products", "CartProducts_Id", c => c.Int());
            DropForeignKey("dbo.CustomerProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.CustomerProducts", "Customer_Id", "dbo.Users");
            DropForeignKey("dbo.ProductCartProducts", "CartProducts_Id", "dbo.CartProducts");
            DropForeignKey("dbo.ProductCartProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.CustomerProducts", new[] { "Product_Id" });
            DropIndex("dbo.CustomerProducts", new[] { "Customer_Id" });
            DropIndex("dbo.ProductCartProducts", new[] { "CartProducts_Id" });
            DropIndex("dbo.ProductCartProducts", new[] { "Product_Id" });
            DropTable("dbo.CustomerProducts");
            DropTable("dbo.ProductCartProducts");
            CreateIndex("dbo.Products", "Customer_Id");
            CreateIndex("dbo.Products", "CartProducts_Id");
            AddForeignKey("dbo.Products", "Customer_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Products", "CartProducts_Id", "dbo.CartProducts", "Id");
        }
    }
}
