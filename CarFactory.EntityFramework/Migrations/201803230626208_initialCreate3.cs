namespace CarFactory.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Banner", "Img", c => c.String(maxLength: 100, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Banner", "Img", c => c.String(maxLength: 50, storeType: "nvarchar"));
        }
    }
}
