namespace ComputerShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shopIncome : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Finances (Name, Amount) VALUES ('Shop Income', .0)");
        }
        
        public override void Down()
        {
        }
    }
}
