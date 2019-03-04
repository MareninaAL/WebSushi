namespace WebTransportCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3Migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.OrderRolls", "RollId", "dbo.Rolls");
            DropForeignKey("dbo.OrderRolls", "OrderId", "dbo.Orders");
            DropIndex("dbo.Orders", new[] { "ClientId" });
            DropIndex("dbo.OrderRolls", new[] { "OrderId" });
            DropIndex("dbo.OrderRolls", new[] { "RollId" });
            RenameColumn(table: "dbo.OrderDrinks", name: "OrderId", newName: "OrderId_drink");
            RenameColumn(table: "dbo.OrderRolls", name: "OrderId", newName: "OrderId_roll");
            RenameColumn(table: "dbo.OrderSalads", name: "OrderId", newName: "OrderId_salad");
            RenameIndex(table: "dbo.OrderDrinks", name: "IX_OrderId", newName: "IX_OrderId_drink");
            RenameIndex(table: "dbo.OrderSalads", name: "IX_OrderId", newName: "IX_OrderId_salad");
            AlterColumn("dbo.Orders", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.Orders", "Summa", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "ClientId", c => c.Int());
            AlterColumn("dbo.OrderRolls", "OrderId_roll", c => c.Int());
            AlterColumn("dbo.OrderRolls", "RollId", c => c.Int());
            AlterColumn("dbo.OrderRolls", "Count", c => c.Int());
            CreateIndex("dbo.Orders", "ClientId");
            CreateIndex("dbo.OrderRolls", "OrderId_roll");
            CreateIndex("dbo.OrderRolls", "RollId");
            AddForeignKey("dbo.Orders", "ClientId", "dbo.Clients", "Id");
            AddForeignKey("dbo.OrderRolls", "RollId", "dbo.Rolls", "Id");
            AddForeignKey("dbo.OrderRolls", "OrderId_roll", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderRolls", "OrderId_roll", "dbo.Orders");
            DropForeignKey("dbo.OrderRolls", "RollId", "dbo.Rolls");
            DropForeignKey("dbo.Orders", "ClientId", "dbo.Clients");
            DropIndex("dbo.OrderRolls", new[] { "RollId" });
            DropIndex("dbo.OrderRolls", new[] { "OrderId_roll" });
            DropIndex("dbo.Orders", new[] { "ClientId" });
            AlterColumn("dbo.OrderRolls", "Count", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderRolls", "RollId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderRolls", "OrderId_roll", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "ClientId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "Summa", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "CreateDate", c => c.DateTime(nullable: false));
            RenameIndex(table: "dbo.OrderSalads", name: "IX_OrderId_salad", newName: "IX_OrderId");
            RenameIndex(table: "dbo.OrderDrinks", name: "IX_OrderId_drink", newName: "IX_OrderId");
            RenameColumn(table: "dbo.OrderSalads", name: "OrderId_salad", newName: "OrderId");
            RenameColumn(table: "dbo.OrderRolls", name: "OrderId_roll", newName: "OrderId");
            RenameColumn(table: "dbo.OrderDrinks", name: "OrderId_drink", newName: "OrderId");
            CreateIndex("dbo.OrderRolls", "RollId");
            CreateIndex("dbo.OrderRolls", "OrderId");
            CreateIndex("dbo.Orders", "ClientId");
            AddForeignKey("dbo.OrderRolls", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderRolls", "RollId", "dbo.Rolls", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
        }
    }
}
