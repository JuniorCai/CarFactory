namespace CarFactory.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Detail", c => c.String(nullable: false, maxLength: 4000, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Detail");
        }
    }
}
