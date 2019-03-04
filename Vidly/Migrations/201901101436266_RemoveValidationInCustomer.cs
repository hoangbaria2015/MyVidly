namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveValidationInCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
