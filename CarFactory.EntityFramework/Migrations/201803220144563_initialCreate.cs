namespace CarFactory.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "Introduce", c => c.String(maxLength: 4000, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Company", "Introduce");
        }
    }
}
