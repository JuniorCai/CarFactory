namespace CarFactory.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banner", "IsShow", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Banner", "IsShow");
        }
    }
}
