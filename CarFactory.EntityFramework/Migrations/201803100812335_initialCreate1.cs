namespace CarFactory.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AbpUserClaims", "ClaimType", c => c.String(maxLength: 256, storeType: "nvarchar"));
            AlterColumn("dbo.AbpUserAccounts", "UserName", c => c.String(maxLength: 32, storeType: "nvarchar"));
            AlterColumn("dbo.AbpUserAccounts", "EmailAddress", c => c.String(maxLength: 256, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AbpUserAccounts", "EmailAddress", c => c.String(unicode: false));
            AlterColumn("dbo.AbpUserAccounts", "UserName", c => c.String(unicode: false));
            AlterColumn("dbo.AbpUserClaims", "ClaimType", c => c.String(unicode: false));
        }
    }
}
