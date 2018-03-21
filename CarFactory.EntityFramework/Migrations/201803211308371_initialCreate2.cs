namespace CarFactory.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "LinkMan", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Company", "LinkMan");
        }
    }
}
