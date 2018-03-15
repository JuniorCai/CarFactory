namespace CarFactory.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Detail", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Detail", c => c.String(nullable: false, maxLength: 4000, storeType: "nvarchar"));
        }
    }
}
