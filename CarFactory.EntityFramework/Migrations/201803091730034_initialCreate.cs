namespace CarFactory.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Report", "Img", c => c.String(maxLength: 100, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Report", "Img", c => c.String(maxLength: 50, storeType: "nvarchar"));
        }
    }
}
