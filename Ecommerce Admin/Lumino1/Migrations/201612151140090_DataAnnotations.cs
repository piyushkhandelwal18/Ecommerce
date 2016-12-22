namespace CommonComponent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "UserFirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "UserLastName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "UserEmailId", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserEmailId", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "UserLastName", c => c.String());
            AlterColumn("dbo.Users", "UserFirstName", c => c.String());
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            AlterColumn("dbo.Categories", "CategoryName", c => c.String());
        }
    }
}
