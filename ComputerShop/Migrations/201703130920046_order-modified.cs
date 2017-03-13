namespace ComputerShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordermodified : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Order_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_ID)
                .Index(t => t.ProductID)
                .Index(t => t.Order_ID);
            
            DropColumn("dbo.Orders", "ProductsJSON");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ProductsJSON", c => c.String());
            DropForeignKey("dbo.Items", "Order_ID", "dbo.Orders");
            DropForeignKey("dbo.Items", "ProductID", "dbo.Products");
            DropIndex("dbo.Items", new[] { "Order_ID" });
            DropIndex("dbo.Items", new[] { "ProductID" });
            DropTable("dbo.Items");
        }
    }
}
