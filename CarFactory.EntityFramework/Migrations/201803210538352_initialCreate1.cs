namespace CarFactory.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Seo", "SiteBannerImgs", c => c.String(maxLength: 1000, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Seo", "SiteBannerImgs", c => c.String(nullable: false, maxLength: 1000, storeType: "nvarchar"));
        }
    }
}
