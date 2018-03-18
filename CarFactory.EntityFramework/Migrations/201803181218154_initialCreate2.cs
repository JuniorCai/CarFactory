namespace CarFactory.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AbpUsers", "EmailAddress", c => c.String(maxLength: 256, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AbpUsers", "EmailAddress", c => c.String(nullable: false, maxLength: 256, storeType: "nvarchar"));
        }
    }
}
