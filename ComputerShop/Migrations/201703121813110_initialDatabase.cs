namespace ComputerShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Finances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Total = c.Double(nullable: false),
                        Time = c.DateTime(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        StockAmount = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.Finances");
        }
    }
}
