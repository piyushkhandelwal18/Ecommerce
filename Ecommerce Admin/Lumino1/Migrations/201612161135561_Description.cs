namespace CommonComponent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Description : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Description", c => c.String());
            AddColumn("dbo.Categories", "Image", c => c.String());
            AddColumn("dbo.Categories", "Discounts", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Discounts");
            DropColumn("dbo.Categories", "Image");
            DropColumn("dbo.Categories", "Description");
        }
    }
}
