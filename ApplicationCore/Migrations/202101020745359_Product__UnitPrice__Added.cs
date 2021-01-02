namespace ApplicationCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Product__UnitPrice__Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "UnitPrice");
        }
    }
}
