namespace CarFactory.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Report", "IsShow", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Report", "IsShow");
        }
    }
}
