namespace WebTransportCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4Migr : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderRolls", "OrderId_roll", "dbo.Orders");
            DropIndex("dbo.OrderRolls", new[] { "OrderId_roll" });
            AddColumn("dbo.OrderRolls", "Order_Id", c => c.Int());
            AddColumn("dbo.Rolls", "OrderId", c => c.Int(nullable: false));
            AddColumn("dbo.Rolls", "Order_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Rolls", "Order_Id");
            CreateIndex("dbo.OrderRolls", "Order_Id");
            AddForeignKey("dbo.Rolls", "Order_Id", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderRolls", "Order_Id", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderRolls", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Rolls", "Order_Id", "dbo.Orders");
            DropIndex("dbo.OrderRolls", new[] { "Order_Id" });
            DropIndex("dbo.Rolls", new[] { "Order_Id" });
            DropColumn("dbo.Rolls", "Order_Id");
            DropColumn("dbo.Rolls", "OrderId");
            DropColumn("dbo.OrderRolls", "Order_Id");
            CreateIndex("dbo.OrderRolls", "OrderId_roll");
            AddForeignKey("dbo.OrderRolls", "OrderId_roll", "dbo.Orders", "Id");
        }
    }
}
