namespace CommonComponent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "MobileNo", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "PhoneNo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "PhoneNo", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "MobileNo", c => c.String(nullable: false));
        }
    }
}
