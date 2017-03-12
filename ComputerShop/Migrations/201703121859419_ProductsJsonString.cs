namespace ComputerShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductsJsonString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ProductsJSON", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "ProductsJSON");
        }
    }
}
