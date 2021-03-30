namespace TelecommunicationDevicesStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SimpleMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Product_Id", "dbo.Products");
            DropIndex("dbo.Customers", new[] { "Product_Id" });
            DropColumn("dbo.Customers", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Product_Id", c => c.Int());
            CreateIndex("dbo.Customers", "Product_Id");
            AddForeignKey("dbo.Customers", "Product_Id", "dbo.Products", "Id");
        }
    }
}
