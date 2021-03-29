namespace TelecommunicationDevicesStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartLineAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "Order_Id" });
            CreateTable(
                "dbo.CartProductsQuantity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.ProductId)
                .Index(t => t.Order_Id);
            
            DropColumn("dbo.Products", "Order_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Order_Id", c => c.Int());
            DropForeignKey("dbo.CartProductsQuantity", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.CartProductsQuantity", "ProductId", "dbo.Products");
            DropIndex("dbo.CartProductsQuantity", new[] { "Order_Id" });
            DropIndex("dbo.CartProductsQuantity", new[] { "ProductId" });
            DropTable("dbo.CartProductsQuantity");
            CreateIndex("dbo.Products", "Order_Id");
            AddForeignKey("dbo.Products", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
