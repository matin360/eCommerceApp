namespace TelecommunicationDevicesStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartProductsRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductCartProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProductCartProducts", "CartProducts_Id", "dbo.CartProducts");
            DropForeignKey("dbo.CartProducts", "UserId", "dbo.Users");
            DropIndex("dbo.CartProducts", new[] { "UserId" });
            DropIndex("dbo.ProductCartProducts", new[] { "Product_Id" });
            DropIndex("dbo.ProductCartProducts", new[] { "CartProducts_Id" });
            DropTable("dbo.CartProducts");
            DropTable("dbo.ProductCartProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductCartProducts",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        CartProducts_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.CartProducts_Id });
            
            CreateTable(
                "dbo.CartProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ProductCartProducts", "CartProducts_Id");
            CreateIndex("dbo.ProductCartProducts", "Product_Id");
            CreateIndex("dbo.CartProducts", "UserId");
            AddForeignKey("dbo.CartProducts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductCartProducts", "CartProducts_Id", "dbo.CartProducts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductCartProducts", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
