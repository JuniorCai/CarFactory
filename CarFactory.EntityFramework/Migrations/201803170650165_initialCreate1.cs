namespace CarFactory.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbpRoles", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AbpRoles", "IsActive");
        }
    }
}
