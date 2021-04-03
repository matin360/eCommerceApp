namespace TelecommunicationDevicesStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartLine_updated : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Customers", newName: "Users");
            DropForeignKey("dbo.CartProductsQuantity", "Order_Id", "dbo.Orders");
            DropIndex("dbo.CartProductsQuantity", new[] { "Order_Id" });
            RenameColumn(table: "dbo.CartProductsQuantity", name: "Order_Id", newName: "OrderId");
            AddColumn("dbo.Users", "UserRole", c => c.Int());
            AddColumn("dbo.Users", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.CartProductsQuantity", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.CartProductsQuantity", "OrderId");
            AddForeignKey("dbo.CartProductsQuantity", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            DropColumn("dbo.Users", "Picture");
            DropTable("dbo.SystemUsers");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.Users", "Picture", c => c.String(maxLength: 50));
            DropForeignKey("dbo.CartProductsQuantity", "OrderId", "dbo.Orders");
            DropIndex("dbo.CartProductsQuantity", new[] { "OrderId" });
            AlterColumn("dbo.CartProductsQuantity", "OrderId", c => c.Int());
            DropColumn("dbo.Users", "Discriminator");
            DropColumn("dbo.Users", "UserRole");
            RenameColumn(table: "dbo.CartProductsQuantity", name: "OrderId", newName: "Order_Id");
            CreateIndex("dbo.CartProductsQuantity", "Order_Id");
            AddForeignKey("dbo.CartProductsQuantity", "Order_Id", "dbo.Orders", "Id");
            RenameTable(name: "dbo.Users", newName: "Customers");
        }
    }
}
